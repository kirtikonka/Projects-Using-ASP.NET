using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TS
{
    public partial class ReTask : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            //if (!IsPostBack)
            //{
            //    BindRejectedTasks();
            //    BindBatchDropDown();
            //    BindUserDropDown();
            //}

            Session["breadCrum"] = "ReTask";

        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text.Trim();
            string attachmentPath = null;

            if (fileAttachment.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileAttachment.FileName);
                    string uploadPath = Server.MapPath("Attachments/") + filename;
                    fileAttachment.SaveAs(uploadPath);
                    attachmentPath = "Attachments/" + filename;
                }
                catch (Exception ex)
                {
                    // Handle file upload error
                    Response.Write("<script>alert('File upload failed. " + ex.Message + "');</script>");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(taskName) && !string.IsNullOrEmpty(attachmentPath))
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ReTask (TaskName, Attachment) VALUES (@TaskName, @Attachment)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TaskName", taskName);
                        cmd.Parameters.AddWithValue("@Attachment", attachmentPath);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            Response.Write("<script>alert('Task assigned successfully.');</script>");
                        }
                        catch (Exception ex)
                        {

                            Response.Write("<script>alert('Error assigning task. " + ex.Message + "');</script>");
                        }
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Please provide both task name and attachment.');</script>");
            }
        }
    }
}