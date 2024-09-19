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
    public partial class TaskReview : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            //if (!IsPostBack)
            //{kk
            //    BindGridView();
            //}

            if (!IsPostBack)
            {
                LoadTaskReviews();
            }
            Session["breadCrum"] = "Task Review";
        }

        private void LoadTaskReviews()
        {
            //string query = @"SELECT u.Id AS UserID, u.fname AS Name, ut.Solution, ut.TaskID, ut.Status 
            //         FROM MyTask ut 
            //         JOIN Users u ON ut.UserId = u.Id";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //gvTasks.DataSource = dt;
            //gvTasks.DataBind();


            try
            {
                string query = @"SELECT u.Id AS UserID, u.fname AS Name, ut.Solution, ut.TaskID, ut.Status 
                         FROM MyTask ut 
                         JOIN Users u ON ut.UserId = u.Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Debug information
                System.Diagnostics.Debug.WriteLine("Column count: " + dt.Columns.Count);
                foreach (DataColumn column in dt.Columns)
                {
                    System.Diagnostics.Debug.WriteLine($"Column name: {column.ColumnName}, Type: {column.DataType}");
                }

                if (dt.Rows.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("First row data:");
                    foreach (DataColumn column in dt.Columns)
                    {
                        System.Diagnostics.Debug.WriteLine($"{column.ColumnName}: {dt.Rows[0][column.ColumnName]}");
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No rows returned from the query.");
                }

                gvTasks.DataSource = dt;
                gvTasks.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in LoadTaskReviews: {ex.Message}");
                lblMessage.Text = "An error occurred while loading tasks: " + ex.Message;
            }
        }

        protected void OnTimeButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int TaskID = Convert.ToInt32(btn.CommandArgument);
            InsertTaskReview(TaskID, "OnTime");

        }

        protected void LateButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int TaskID = Convert.ToInt32(btn.CommandArgument);
            InsertTaskReview(TaskID, "Late");

        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int TaskID = Convert.ToInt32(btn.CommandArgument);
            ApproveTask(TaskID);
            Response.Redirect("AssignScore.aspx");
        }

        protected void RejectButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int TaskID = Convert.ToInt32(btn.CommandArgument);
            RejectTask(TaskID);
            Response.Redirect("ReTask.aspx");
        }

        private void InsertTaskReview(int TaskID, string status)
        {
            string query = @"INSERT INTO TaskReview (TaskID, UserId, Username,Solution, Status,AssignedDate)
            SELECT ut.TaskID, u.Id, u.fname, ut.Solution,ut.Status,ut.AssignedDate
            FROM MyTask ut
            JOIN Users u ON ut.UserId = u.id
            WHERE ut.TaskID = @TaskID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TaskID", TaskID);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.ExecuteNonQuery();
            UpdateUserTaskStatus(TaskID, status);
        }

        private void UpdateUserTaskStatus(int TaskID, string status)
        {
            string query = "UPDATE MyTask SET Status = @Status WHERE TaskID= @TaskID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TaskID", TaskID);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.ExecuteNonQuery();
            lblMessage.Text = "updated successfully";
        }
        private void ApproveTask(int TaskID)
        {

        }

        private void RejectTask(int TaskID)
        {

        }
        protected void gvTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



















        //private void BindGridView()
        //{
        //    using (SqlCommand cmd = new SqlCommand("taskreviewproc", conn))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        GridViewTaskReview.DataSource = cmd.ExecuteReader();
        //        GridViewTaskReview.DataBind();
        //    }
        //}

        //protected void GridViewTaskReview_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int taskId = Convert.ToInt32(e.CommandArgument);

        //    switch (e.CommandName)
        //    {
        //        case "DownloadAttachment":
        //            DownloadAttachment(taskId);
        //            break;
        //        case "ApproveTask":
        //            ApproveTask(taskId);
        //            break;
        //        case "RejectTask":
        //            RejectTask(taskId);
        //            break;
        //    }
        //}

        //private void DownloadAttachment(int taskId)
        //{
        //    using (SqlCommand cmd = new SqlCommand("SELECT Solution FROM MyTask WHERE TaskID = @TaskID", conn))
        //    {
        //        cmd.Parameters.AddWithValue("@TaskID", taskId);
        //        conn.Open();
        //        object result = cmd.ExecuteScalar();

        //if (result != null && result != DBNull.Value)
        //{
        //    string fileName = result.ToString();
        //    string filePath = Server.MapPath("~/Uploads") + fileName;

        //    if (File.Exists(filePath))
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/octet-stream";
        //        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        //        Response.TransmitFile(filePath);
        //        Response.End();
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('File not found.');</script>");
        //    }
        //}
        //else
        //{
        //    Response.Write("<script>alert('No attachment found for this task.');</script>");
        //}
        //    }
        //}

        //private void ApproveTask(int taskId)
        //{
        //        using (SqlTransaction transaction = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                using (SqlCommand cmd = new SqlCommand("UPDATE MyTask SET Status = 'Approved' WHERE TaskID = @TaskID", conn, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@TaskID", taskId);
        //                    cmd.ExecuteNonQuery();
        //                }

        //                // Insert into History table
        //                using (SqlCommand cmd = new SqlCommand(@"
        //            INSERT INTO History (TaskID, UserID, TaskName, SubmittedOn, ApprovedOn, Score, Attachment, Status)
        //            SELECT TaskID, UserID, TaskName, SubmittedOn, GETDATE(), @Score, Solution, 'Approved'
        //            FROM MyTask
        //            WHERE TaskID = @TaskID", conn, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@TaskID", taskId);
        //                    //cmd.Parameters.AddWithValue("@Score", score);
        //                    cmd.ExecuteNonQuery();
        //                }

        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
        //            }
        //        }
        //        using (SqlCommand cmd = new SqlCommand("INSERT INTO ApprovedTasks (TaskID, UserID, TaskName, SubmittedOn, Attachment, Status) SELECT TaskID, UserID, TaskName, SubmittedOn, Solution, 'Approved' FROM MyTask WHERE TaskID = @TaskID", conn))
        //    {
        //        cmd.Parameters.AddWithValue("@TaskID", taskId);
        //        cmd.ExecuteNonQuery();
        //    }
        //    BindGridView();
        //}

        //private void RejectTask(int taskId)
        //{
        //    using (SqlCommand cmd = new SqlCommand("INSERT INTO RejectedTasks (TaskID, UserID, TaskName, SubmittedOn, Status) SELECT TaskID, UserID, TaskName, SubmittedOn, 'Rejected' FROM MyTask WHERE TaskID = @TaskID", conn))
        //    {
        //        cmd.Parameters.AddWithValue("@TaskID", taskId);
        //        cmd.ExecuteNonQuery();
        //    }

        //    using (SqlCommand updateCmd = new SqlCommand("UPDATE MyTask SET Status = 'Rejected' WHERE TaskID = @TaskID", conn))
        //    {
        //        updateCmd.Parameters.AddWithValue("@TaskID", taskId);
        //        updateCmd.ExecuteNonQuery();
        //    }
        //    BindGridView();
        //}
    }
}