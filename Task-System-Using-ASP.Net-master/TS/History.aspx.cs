using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TS
{
    public partial class History : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                if (Session["myuser"] != null)
                {
                    BindHistoryGrid();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        private void BindHistoryGrid()
        {
            string userEmail = Session["myuser"].ToString();
            string query = @"SELECT mt.TaskID, mt.TaskName, mt.AssignedDate, mt.FinishedDate, mt.Score, mt.Status
                             FROM MyTask mt
                             INNER JOIN Users u ON mt.UserID = u.Id
                             WHERE u.Email = @UserEmail AND mt.Score IS NOT NULL
                             ORDER BY mt.AssignedDate DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridViewHistory.DataSource = dt;
                    GridViewHistory.DataBind();
                }
            }
        }
        //private void BindHistoryGrid()
        //{
        //        using (SqlCommand cmd = new SqlCommand("historyproc", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
        //            conn.Open();
        //            GridViewHistory.DataSource = cmd.ExecuteReader();
        //            GridViewHistory.DataBind();
        //        }
        //}

        protected void GridViewHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DownloadAttachment")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int taskId = Convert.ToInt32(GridViewHistory.DataKeys[index]["TaskID"]);

                DownloadAttachment(taskId);
            }
        }

        private void DownloadAttachment(int taskId)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT TaskName, Attachment FROM History WHERE TaskID = @TaskID", conn))
            {
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string taskName = reader["TaskName"].ToString();
                        string attachmentPath = reader["Attachment"].ToString();

                        if (!string.IsNullOrEmpty(attachmentPath))
                        {
                            // Assuming the attachment is stored as a file path
                            string filePath = Server.MapPath(attachmentPath);
                            Response.ContentType = "application/octet-stream";
                            Response.AppendHeader("Content-Disposition", $"attachment; filename={taskName}");
                            Response.TransmitFile(filePath);
                            Response.End();
                        }
                    }
                }
                //if (reader.Read())
                //    {
                //        string taskName = reader["TaskName"].ToString();
                //        byte[] fileData = (byte[])reader["Attachment"];

                //        Response.Clear();
                //        Response.ContentType = "application/octet-stream";
                //        Response.AddHeader("Content-Disposition", $"attachment; filename={taskName}.pdf");
                //        Response.BinaryWrite(fileData);
                //        Response.End();
                //    }
            }
        }
    }
}