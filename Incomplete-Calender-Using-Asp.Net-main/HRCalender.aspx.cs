using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace calender
{
    public partial class HRCalender : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=calender;Integrated Security=True;MultipleActiveResultSets=True";
        private static readonly DateTime minDate = new DateTime(1753, 1, 1);
        private static readonly DateTime maxDate = new DateTime(9999, 12, 31);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadEvents();
            }
        }

        private void LoadEvents()
        {
            if (Calendar1.SelectedDate < minDate || Calendar1.SelectedDate > maxDate)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid date selected. Please choose a date between 1/1/1753 and 12/31/9999.');", true);
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT EventID, EventName, EventDate FROM Events WHERE EventDate = @SelectedDate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SelectedDate", Calendar1.SelectedDate);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //DateTime convertedInitDate = DateTime.ParseExact(initDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                //cCCBEntities.initDate = convertedInitDate;


                //string expirationDate = DateTable();
                //string date = Convert.ToDateTime(expirationDate).ToString("yyyy-MM-dd");



                DateTime selectedDate = Calendar1.SelectedDate;
                if (selectedDate < minDate || selectedDate > maxDate)
                {
                    // Show an error message to the user
                    // For example:
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid date selected. Please choose a date between 1/1/1753 and 12/31/9999.');", true);
                    return;
                }

                DateTime myDateTime = DateTime.Today;

                //ddlEvents.DataSource = dt;
                //ddlEvents.DataTextField = "EventName";
                //ddlEvents.DataValueField = "EventID";
                //ddlEvents.DataBind();

                //da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    // Handle the case where there are no events for the selected date
                    ddlEvents.DataSource = null;
                    ddlEvents.DataBind();
                    // You can display a message like "No events found for this date"
                }
                else
                {
                    // Existing code for binding data to dropdown
                    ddlEvents.DataSource = dt;
                    ddlEvents.DataTextField = "EventName";
                    ddlEvents.DataValueField = "EventID";
                    ddlEvents.DataBind();
                }

            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            LoadEvents();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate < minDate || Calendar1.SelectedDate > maxDate)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid date selected. Please choose a date between 1/1/1753 and 12/31/9999.');", true);
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Events (EventName, EventDate, Description) VALUES (@EventName, @EventDate, @Description)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EventName", txtEventName.Text);
                cmd.Parameters.AddWithValue("@EventDate", Calendar1.SelectedDate);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadEvents();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ddlEvents.SelectedValue != "")
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Events WHERE EventID = @EventID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EventID", ddlEvents.SelectedValue);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadEvents();
            }
        }





        //protected void btnAddEvent_Click(object sender, EventArgs e)
        //{
        //    DateTime eventDate;
        //    if (!DateTime.TryParse(txtEventDate.Text, out eventDate))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid date format. Please enter a valid date.');", true);
        //        return;
        //    }

        //    if (eventDate < minDate || eventDate > maxDate)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid date entered. Please choose a date between 1/1/1753 and 12/31/9999.');", true);
        //        return;
        //    }

        //    // Retrieve values from form controls
        //    string eventType = ddlEventType.SelectedValue;
        //    eventDate = DateTime.Parse(txtEventDate.Text);
        //    string description = txtDescription.Text;

        //    // Insert into database
        //    string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = "INSERT INTO Events (EventType, EventDate, Description) VALUES (@EventType, @EventDate, @Description)";
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@EventType", eventType);
        //        cmd.Parameters.AddWithValue("@EventDate", eventDate);
        //        cmd.Parameters.AddWithValue("@Description", description);

        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }

        //    // Refresh events list
        //    BindEvents();
        //}

        //protected void btnDelete_Command(object sender, CommandEventArgs e)
        //{
        //    int eventID = Convert.ToInt32(e.CommandArgument);

        //    // Delete from database
        //    string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = "DELETE FROM Events WHERE EventID = @EventID";
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@EventID", eventID);

        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }

        //    // Refresh events list
        //    BindEvents();
        //}

        //private void BindEvents()
        //{
        //    // Fetch events from database and bind to repeater
        //    DataTable dtEvents = new DataTable();
        //    string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT EventID, EventType, EventDate, Description FROM Events";
        //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
        //        da.Fill(dtEvents);
        //    }

        //    rptEvents.DataSource = dtEvents;
        //    rptEvents.DataBind();
        //}



        protected void imgEventDate_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true; // Show the calendar
        }

        //protected void ddlEvents_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    {
        //        if (!string.IsNullOrEmpty(ddlEvents.SelectedValue))
        //        {
        //            int eventID = Convert.ToInt32(ddlEvents.SelectedValue);

        //            using (SqlConnection conn = new SqlConnection(connectionString))
        //            {
        //                string query = "SELECT EventName, EventDate, Description FROM Events WHERE EventID = @EventID";
        //                using (SqlCommand cmd = new SqlCommand(query, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@EventID", eventID);

        //                    try
        //                    {
        //                        conn.Open();
        //                        using (SqlDataReader reader = cmd.ExecuteReader())
        //                        {
        //                            if (reader.Read())
        //                            {
        //                                // Assuming you have TextBox controls to display event details
        //                                txtEventName.Text = reader["EventName"].ToString();
        //                                string EventDate = Convert.ToDateTime(reader["EventDate"]).ToString("yyyy-MM-dd");
        //                                txtDescription.Text = reader["Description"].ToString();

        //                                btnDelete.Enabled = true;
        //                            }
        //                            else
        //                            {
        //                                ClearEventDetails();
        //                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Event not found.');", true);
        //                            }
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        // Log the error
        //                        System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
        //                        // Inform the user
        //                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An error occurred while loading event details. Please try again.');", true);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ClearEventDetails();
        //        }
        //    }


        //    void ClearEventDetails()
        //    {
        //        // Clear the TextBox controls
        //        txtEventName.Text = string.Empty;
        //        string EventDate = string.Empty;
        //        txtDescription.Text = string.Empty;

        //        btnDelete.Enabled = false;
        //    }
        }
    }
}