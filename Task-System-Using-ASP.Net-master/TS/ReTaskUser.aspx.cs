using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TS
{
    public partial class ReTaskUser : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                if (Session["UserID"] != null && Session["BatchID"] != null)
                {
                    BindRejectedTasks();
                }
                else
                {
                    //Response.Redirect("Login.aspx");
                }
            }
        }
        private void BindRejectedTasks()
        {
            using (SqlCommand cmd = new SqlCommand("retaskuserproc", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                cmd.Parameters.AddWithValue("@BatchID", Session["BatchID"]);
                conn.Open();
                GridViewRejectedTasks.DataSource = cmd.ExecuteReader();
                GridViewRejectedTasks.DataBind();
            }
        }

        protected void GridViewRejectedTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SubmitTask")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewRejectedTasks.Rows[index];
                FileUpload fileUpload = (FileUpload)row.FindControl("FileUploadSolution");

                if (fileUpload.HasFile)
                {
                    int taskId = Convert.ToInt32(GridViewRejectedTasks.DataKeys[index]["TaskID"]);
                    int reTaskId = Convert.ToInt32(GridViewRejectedTasks.DataKeys[index]["ID"]);

                    byte[] fileContent;
                    using (BinaryReader br = new BinaryReader(fileUpload.PostedFile.InputStream))
                    {
                        fileContent = br.ReadBytes(fileUpload.PostedFile.ContentLength);
                    }

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Update ReTaskUser table
                            using (SqlCommand cmd = new SqlCommand("UPDATE ReTaskUser SET ReSolution = @ReSolution, ReSubmittedOn = GETDATE(), Status = 'ReSubmitted' WHERE ID = @ReTaskID", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ReSolution", fileContent);
                                cmd.Parameters.AddWithValue("@ReTaskID", reTaskId);
                                cmd.ExecuteNonQuery();
                            }

                            // Insert into MyTask table for admin review
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO MyTask (TaskID, UserID, TaskName, SubmittedOn, Solution, Status) SELECT TaskID, UserID, TaskName, GETDATE(), @Solution, 'Pending' FROM ReTaskUser WHERE ID = @ReTaskID", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Solution", fileContent);
                                cmd.Parameters.AddWithValue("@ReTaskID", reTaskId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            // Log the error and show a message to the user
                            Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
                        }
                    }

                    BindRejectedTasks();
                }
                else
                {
                    Response.Write("<script>alert('Please select a file to upload.');</script>");
                }
            }
        }
    }
}