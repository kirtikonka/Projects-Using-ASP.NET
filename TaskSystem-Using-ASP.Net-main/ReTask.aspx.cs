using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                    string query = "INSERT INTO ReTasks (TaskName, Attachment) VALUES (@TaskName, @Attachment)";
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


















        //private void BindRejectedTasks()
        //{
        //    string q = "retaskproc";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    GridViewRejectedTasks.DataSource = cmd.ExecuteReader();
        //    GridViewRejectedTasks.DataBind();
        //}

        //private void BindBatchDropDown()
        //{
        //        using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Batch FROM MyTask WHERE Status = 'Rejected'", conn))
        //        {
        //            DropDownListBatch.DataSource = cmd.ExecuteReader();
        //            DropDownListBatch.DataTextField = "Batch";
        //            DropDownListBatch.DataValueField = "Batch";
        //            DropDownListBatch.DataBind();
        //        }
        //    DropDownListBatch.Items.Insert(0, new ListItem("Select Batch", ""));
        //}

        //private void BindUserDropDown()
        //{
        //        using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT UserID, TaskName FROM MyTask WHERE Status = 'Rejected'", conn))
        //        {
        //            DropDownListUser.DataSource = cmd.ExecuteReader();
        //            DropDownListUser.DataTextField = "TaskName";
        //            DropDownListUser.DataValueField = "UserID";
        //            DropDownListUser.DataBind();
        //        }
        //    DropDownListUser.Items.Insert(0, new ListItem("Select User", ""));
        //}

        //protected void ButtonAssign_Click(object sender, EventArgs e)
        //{
        //    string taskName = TextBoxTaskName.Text;
        //    string attachment = "";
        //    if (FileUploadAttachment.HasFile)
        //    {
        //        attachment = SaveAttachment();
        //    }
        //    string batch = DropDownListBatch.SelectedValue;
        //    int userId = Convert.ToInt32(DropDownListUser.SelectedValue);

        //    UpdateMyTask(taskName, attachment, batch, userId);

        //    ClearForm();
        //    BindRejectedTasks();
        //}

        //private string SaveAttachment()
        //{
        //    string fileName = Path.GetFileName(FileUploadAttachment.FileName);
        //    string filePath = Server.MapPath("~/Attachments") + fileName;
        //    FileUploadAttachment.SaveAs(filePath);
        //    return fileName;
        //}

        //private void UpdateMyTask(string taskName, string attachment, string batch, int userId)
        //{
        //        using (SqlCommand cmd = new SqlCommand("UPDATE MyTask SET TaskName = @TaskName, Attachment = @Attachment, Batch = @Batch, Status = 'Assigned', SubmittedOn = GETDATE() WHERE UserID = @UserID AND Status = 'Rejected'", conn))
        //        {
        //            cmd.Parameters.AddWithValue("@TaskName", taskName);
        //            cmd.Parameters.AddWithValue("@Attachment", attachment);
        //            cmd.Parameters.AddWithValue("@Batch", batch);
        //            cmd.Parameters.AddWithValue("@UserID", userId);
        //            cmd.ExecuteNonQuery();
        //        }
        //}

        //private void ClearForm()
        //{
        //    TextBoxTaskName.Text = "";
        //    DropDownListBatch.SelectedIndex = 0;
        //    DropDownListUser.SelectedIndex = 0;
        //}
    }
}