using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TS
{
    public partial class MyTask : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                if (Session["myuser"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                LoadTasks();
            }
        }
        private void LoadTasks()
        {
            //string q = "SELECT TaskId, TaskName, Attachment, CreatedDateTime AS AssignedDate FROM AssignTask";
            //SqlCommand cmd = new SqlCommand(q, conn);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //TaskGridView.DataSource = dt;
            //TaskGridView.DataBind();

            string userEmail = Session["myuser"].ToString();
            string q = @"SELECT AT.TaskId, AT.TaskName, AT.Attachment, AT.CreatedDateTime AS AssignedDate 
                 FROM AssignTask AT
                 INNER JOIN UserTasks UT ON AT.TaskId = UT.TaskId
                 WHERE UT.UserEmail = @UserEmail";

            using (SqlCommand cmd = new SqlCommand(q, conn))
            {
                cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        TaskGridView.DataSource = dt;
                        TaskGridView.DataBind();
                        TaskGridView.Visible = true;
                        lblNoTasks.Visible = false;
                    }
                    else
                    {
                        TaskGridView.Visible = false;
                        lblNoTasks.Visible = true;
                    }
                }
            }
        }

        protected void UploadSolutionButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            FileUpload fileUpload = (FileUpload)row.FindControl("SolutionUpload");
            string taskId = button.CommandArgument;

            if (fileUpload.HasFile)
            {
                string filePath = Server.MapPath("Uploads/") + fileUpload.FileName;
                fileUpload.SaveAs(filePath);

                DateTime AssignedDate;
                    using (SqlCommand cmd = new SqlCommand("SELECT CreatedDateTime AS AssignedDate FROM AssignTask WHERE TaskId = @TaskId", conn))
                    {
                        cmd.Parameters.AddWithValue("@TaskId", taskId);
                        AssignedDate = (DateTime)cmd.ExecuteScalar();
                    }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO MyTask (TaskId, Solution, AssignedDate) VALUES (@TaskId, @Solution, @AssignedDate)", conn))
                {
                    cmd.Parameters.AddWithValue("@Solution", filePath);
                    cmd.Parameters.AddWithValue("@AssignedDate", AssignedDate);
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.ExecuteNonQuery();
                }

                Response.Write("<script>alert('Solution uploaded successfully.');</script>");
            }
        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in TaskGridView.Rows)
            {
                int taskId = Convert.ToInt32(TaskGridView.DataKeys[row.RowIndex].Value);
                FileUpload fileUpload = (FileUpload)row.FindControl("FileUploadSolution");
                RadioButtonList statusList = (RadioButtonList)row.FindControl("RadioButtonListStatus");

                string solution = string.Empty;
                if (fileUpload.HasFile)
                {
                    solution = SaveSolutionFile(fileUpload);
                }

                string status = statusList.SelectedValue;

                UpdateTaskSubmission(taskId, solution, status);
            }
        }

        protected void OntimeButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string taskId = button.CommandArgument;

            UpdateTaskStatus(taskId, "Ontime");
        }

        protected void LateButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string taskId = button.CommandArgument;

            UpdateTaskStatus(taskId, "Late");
        }

        private void UpdateTaskStatus(string taskId, string status)
        {
            DateTime AssignedDate;

            using (SqlCommand cmd = new SqlCommand("SELECT CreatedDateTime AS AssignedDate FROM AssignTask WHERE TaskId = @TaskId", conn ))
            {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    AssignedDate = (DateTime)cmd.ExecuteScalar();
            }

                using (SqlCommand cmd = new SqlCommand("UPDATE MyTask SET Status = @Status, FinishedDate = @FinishedDate, AssignedDate = @AssignedDate WHERE TaskId = @TaskId", conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@FinishedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AssignedDate", AssignedDate);
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Task status updated successfully.');</script>");
                }
            LoadTasks();
        }
        protected void TaskGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object AssignedDateObj = DataBinder.Eval(e.Row.DataItem, "AssignedDate");

                if (AssignedDateObj != DBNull.Value)
                {
                    DateTime assignDate = Convert.ToDateTime(AssignedDateObj);
                    Button ontimeButton = (Button)e.Row.FindControl("OntimeButton");
                    Button lateButton = (Button)e.Row.FindControl("LateButton");

                    if ((DateTime.Now - assignDate).TotalHours > 48)
                    {
                        ontimeButton.Enabled = true;
                        lateButton.Enabled = false;
                    }
                }
                else
                {
                    Button ontimeButton = (Button)e.Row.FindControl("OntimeButton");
                    Button lateButton = (Button)e.Row.FindControl("LateButton");
                    ontimeButton.Enabled = false;
                    lateButton.Enabled = true;
                }
            }
        }
        private void UpdateTaskSubmission(int taskId, string solution, string status)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE MyTask SET Solution = @Solution, Status = @Status WHERE TaskID = @TaskID", conn))
            {
                cmd.Parameters.AddWithValue("@Solution", solution);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                cmd.ExecuteNonQuery();
            }
        }
        private void DownloadAttachment(int taskId)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Attachment FROM MyTask WHERE TaskID = @TaskID", conn))
            {
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                conn.Open();
                string fileName = (string)cmd.ExecuteScalar();

                if (!string.IsNullOrEmpty(fileName))
                {
                    string filePath = Server.MapPath("Attachments/") + fileName;
                    if (File.Exists(filePath))
                    {
                        Response.Clear();
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                        Response.TransmitFile(filePath);
                        Response.End();
                    }
                }
            }
        }

        private string SaveSolutionFile(FileUpload fileUpload)
        {
            string fileName = Path.GetFileName(fileUpload.FileName);
            string filePath = Server.MapPath("~/Uploads") + fileName;
            fileUpload.SaveAs(filePath);
            return fileName;
        }
    }
}