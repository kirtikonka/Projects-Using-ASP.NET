using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace calender
{
    public class GetEvents : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            //context.Response.Write("Hello World");
            List<Event> events = new List<Event>();

            // Fetch events from database
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT EventID, EventType, EventDate, Description FROM Events";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Event evt = new Event
                    {
                        EventID = Convert.ToInt32(reader["EventID"]),
                        EventType = reader["EventType"].ToString(),
                        EventDate = Convert.ToDateTime(reader["EventDate"]),
                        Description = reader["Description"].ToString()
                    };
                    events.Add(evt);
                }
            }

            // Serialize events to JSON
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(events);

            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class Event
    {
        public int EventID { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
    }
    
}



