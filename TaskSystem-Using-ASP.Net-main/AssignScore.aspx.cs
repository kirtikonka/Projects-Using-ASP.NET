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
    public partial class AssignScore : System.Web.UI.Page
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
                LoadTasksForScoring();
                LoadUserScores();
            }
        }
        private void LoadUserScores()
        {
            string userEmail = Session["myuser"].ToString();

            string query = @"
                SELECT mt.TaskName, mt.AssignedDate, mt.FinishedDate, mt.Score, mt.Status
                FROM MyTask mt
                INNER JOIN Users u ON mt.UserID = u.Id
                WHERE u.Email = @UserEmail
                ORDER BY mt.AssignedDate DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    AssignScoreGridView.DataSource = dt;
                    AssignScoreGridView.DataBind();
                }
            }
        }
        private void LoadTasksForScoring()
        {
            string userEmail = Session["myuser"].ToString();

            string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            System.Diagnostics.Debug.WriteLine($"User Email from Session: {Session["myuser"]}");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = @"SELECT ut.TaskID, u.fname, u.Email AS UserEmail, ut.FinishedDate, ut.Status  
                             FROM MyTask ut  
                             INNER JOIN Users u ON ut.UserId = u.Id  
                             WHERE ut.Status = 'Ontime' and u.email = @UserEmail";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            // Log the column names for debugging
                            foreach (DataColumn column in dt.Columns)
                            {
                                System.Diagnostics.Debug.WriteLine($"Column name: {column.ColumnName}");
                            }
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataColumn column in dt.Columns)
                                {
                                    System.Diagnostics.Debug.WriteLine($"{column.ColumnName}: {dt.Rows[0][column.ColumnName]}");
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("No rows returned from the query.");
                            }
                            AssignScoreGridView.DataSource = dt;
                            AssignScoreGridView.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in LoadTasksForScoring: {ex.Message}");
                lblMessage.Text = "An error occurred while loading tasks.";
            }
        }
        protected void AssignScoreButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            TextBox scoreTextBox = (TextBox)row.FindControl("ScoreTextBox");
            string taskId = button.CommandArgument;
            int score;
            //string status;
            //string taskname;

            if (int.TryParse(scoreTextBox.Text, out score))
            {
                string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE MyTask SET Score = @Score WHERE TaskID= @TaskID", conn))
                    {
                        //cmd.Parameters.AddWithValue("@taskname", taskname);
                        //cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Score", score);
                        cmd.Parameters.AddWithValue("@TaskID", taskId);
                        cmd.ExecuteNonQuery();
                        lblMessage.Text = "Score Added";
                    }
                }
            }

            else if(!string.IsNullOrEmpty(scoreTextBox.Text))
            {
                score = int.Parse(scoreTextBox.Text);
                string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE MyTask SET Status = @Status WHERE TaskID = @TaskID", conn))
                        {
                            cmd.Parameters.AddWithValue("@Status", score); // Changed from @Status to @Score
                            cmd.Parameters.AddWithValue("@TaskID", taskId);
                            cmd.ExecuteNonQuery();
                            lblMessage.Text = "Score Updated";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "An error occurred: " + ex.Message;
                    }
                }
            }
            else
            {

                Response.Write("<script>alert('Please enter a valid score.');</script>");
            }
        }


        //private void BindGridView()
        //{
        //    string q = "assignscoreproc";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    GridViewAssignScore.DataSource = cmd.ExecuteReader();
        //    GridViewAssignScore.DataBind();
        //}

        //protected void GridViewAssignScore_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "AddScore")
        //    {
        //        int taskId = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        //        DropDownList ddlScore = (DropDownList)row.FindControl("DropDownListScore");

        //        if (!string.IsNullOrEmpty(ddlScore.SelectedValue))
        //        {
        //            int score = Convert.ToInt32(ddlScore.SelectedValue);
        //            UpdateScore(taskId, score);
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('Please select a score.');</script>");
        //        }
        //    }
        //}

        //private void UpdateScore(int taskId, int score)
        //{
        //    string q = "InsertAssignScore";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@TaskID", taskId);
        //        cmd.Parameters.AddWithValue("@Score", score);
        //        cmd.ExecuteNonQuery();
        //    BindGridView();
        //}
    }
}