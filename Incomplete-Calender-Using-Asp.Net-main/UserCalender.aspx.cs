using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace calender
{
    public partial class UserCalender : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=calender;Integrated Security=True;MultipleActiveResultSets=True";
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT EventName, Description FROM Events WHERE EventDate = @EventDate";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@EventDate", e.Day.Date);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    e.Cell.Controls.Add(new LiteralControl("<br />"));
                    e.Cell.Controls.Add(new LiteralControl(reader["EventName"].ToString()));
                    e.Cell.Controls.Add(new LiteralControl("<br />"));
                    e.Cell.Controls.Add(new LiteralControl(reader["Description"].ToString()));

                }
            }
        }
    }
}