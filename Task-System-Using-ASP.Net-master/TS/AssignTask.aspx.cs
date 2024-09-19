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
    public partial class AssignTask : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
            if (Session["myuser"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                BindBatches();
                LoadUserTasks();
            }
            Session["breadCrum"] = "Assign Task";
        }
        protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBatch = DropDownList1.SelectedValue;
            LoadUsers(selectedBatch);
            BindUsers();
        }

        private void LoadUsers(string batch)
        {
            string query = "SELECT id, fname, email FROM Users WHERE Batch = @Batch";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Batch", batch);
            SqlDataReader reader = cmd.ExecuteReader();

            CheckBoxList1.Items.Clear();
            while (reader.Read())
            {
                string email = reader["email"].ToString();
                string fname = reader["fname"].ToString();
                ListItem item = new ListItem(fname, email);
                CheckBoxList1.Items.Add(item);
                System.Diagnostics.Debug.WriteLine($"Added user: Name={fname}, Email={email}");
            }
        }
        protected void btnAssign_Click(object sender, EventArgs e)
        {
            string taskName = TextBox1.Text;
            string batch = DropDownList1.SelectedValue;
            string attachment = "";
            string userEmail = Session["myuser"].ToString();

            if (FileUpload1.HasFile)
            {
                string filePath = Path.Combine(Server.MapPath("Attachments/"), FileUpload1.FileName);
                FileUpload1.SaveAs(filePath);
                attachment = FileUpload1.FileName;
            }

            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(taskName))
                    {
                        lblMessage.Text = "Error: Task name cannot be empty";
                        return;
                    }

                    string q = "INSERT INTO AssignTask (TaskName, Attachment, Batch, UserEmail, CreatedDateTime) VALUES (@TaskName, @Attachment, @Batch, @UserEmail, @CreatedDateTime); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(q, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@TaskName", taskName);
                        cmd.Parameters.AddWithValue("@Attachment", attachment);
                        cmd.Parameters.AddWithValue("@Batch", batch);
                        cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                        cmd.Parameters.AddWithValue("@CreatedDateTime", DateTime.Now);

                        int taskId = Convert.ToInt32(cmd.ExecuteScalar());

                        string getUserIdQuery = "SELECT id FROM Users WHERE email = @Email";
                        int userId;
                        using (SqlCommand getUserIdCmd = new SqlCommand(getUserIdQuery, conn, transaction))
                        {
                            getUserIdCmd.Parameters.AddWithValue("@Email", userEmail);
                            userId = Convert.ToInt32(getUserIdCmd.ExecuteScalar());
                        }

                        string userTaskQuery = "INSERT INTO MyTask (UserID, TaskID, TaskName, AssignedDate, Status, finisheddate) VALUES (@UserID, @TaskID, @TaskName, @AssignedDate, @Status, @FinishedDate)";
                        using (SqlCommand userTaskCmd = new SqlCommand(userTaskQuery, conn, transaction))
                        {
                            userTaskCmd.Parameters.AddWithValue("@UserID", userId);
                            userTaskCmd.Parameters.AddWithValue("@TaskID", taskId);
                            userTaskCmd.Parameters.AddWithValue("@TaskName", taskName);
                            userTaskCmd.Parameters.AddWithValue("@AssignedDate", DateTime.Now);
                            userTaskCmd.Parameters.AddWithValue("@Status", "Assigned");
                            userTaskCmd.Parameters.AddWithValue("@FinishedDate", DateTime.MaxValue);
                            userTaskCmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    lblMessage.Text = "Task assigned successfully";
                    LoadUserTasks();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    lblMessage.Text = "Error: " + ex.Message;
                    System.Diagnostics.Debug.WriteLine("Error: " + ex.ToString());
                }
            }
        }

        private void LoadUserTasks()
        {
            string userEmail = Session["myuser"].ToString();
            string query = @"SELECT TaskName, AssignedDate, Status 
                         FROM MyTask 
                         INNER JOIN Users ON MyTask.UserID = Users.id 
                         WHERE Users.email = @UserEmail
                         ORDER BY AssignedDate DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        GridViewTasks.DataSource = dt;
                        GridViewTasks.DataBind();
                        GridViewTasks.Visible = true;
                        lblNoTasks.Visible = false;
                    }
                    else
                    {
                        GridViewTasks.Visible = false;
                        lblNoTasks.Visible = true;
                    }
                }
            }
        }
        private void BindBatches()
        {
            string q = "SELECT DISTINCT batch FROM users";
            SqlCommand cmd = new SqlCommand(q, conn);
            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataTextField = "batch";
            DropDownList1.DataValueField = "batch";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Batch", ""));
        }
        private void BindUsers()
        {
            string selectedBatch = DropDownList1.SelectedValue;
            string q = "SELECT fname + ' ' + lname AS fullname, email FROM users WHERE batch = @batch";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@batch", selectedBatch);
            CheckBoxList1.DataSource = cmd.ExecuteReader();
            CheckBoxList1.DataTextField = "fullname";
            CheckBoxList1.DataValueField = "email";
            CheckBoxList1.DataBind();
            CheckBoxList1.Items.Insert(0, new ListItem("Select User", ""));
        }
    }
}