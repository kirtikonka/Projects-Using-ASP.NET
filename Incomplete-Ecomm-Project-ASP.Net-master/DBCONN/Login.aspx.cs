using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBCONN
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String user = TextBox3.Text;
            string password = TextBox4.Text;
            string email = TextBox5.Text;
            string role = "User";

            String query = $"exec UserSignUp '{user}','{password}','{email}','{role}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('user Registerd')</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String email = TextBox1.Text, password = TextBox2.Text;
            String query = $"exec UserSignIn '{email}','{password}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["email"].Equals(email) && reader["pass"].Equals(password) && reader["urole"].Equals("Admin"))
                    {
                        Session["myuser"] = email; //set session
                        Response.Redirect("AdminHome.aspx");

                    }

                    if (reader["email"].Equals(email) && reader["pass"].Equals(password) && reader["urole"].Equals("User"))
                    {
                        Session["myuser"] = email;
                        Response.Redirect("UserHome.aspx");

                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Email or Password')</script>");
            }
        }
    }
}