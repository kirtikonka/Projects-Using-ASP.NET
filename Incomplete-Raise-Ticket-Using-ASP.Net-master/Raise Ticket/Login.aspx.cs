using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Raise_Ticket
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string name, email, pass, role = "User";
            name = TextBox4.Text;
            email = TextBox3.Text;
            pass = TextBox5.Text;

            string q1 = "exec UserExistproc '" + name + "','" + email + "'";
            SqlCommand c1 = new SqlCommand(q1, conn);
            SqlDataReader r = c1.ExecuteReader();
            if (r.HasRows)
            {
                Response.Write("<script>alert('username and email already exist.')</script>");
            }
            else
            {
                string q = "exec New_User_accountproc '" + name + "','" + email + "','" + pass + "','" + role + "'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Registration succesfull')</script>");
                ClearText();
            }
        }
        private void ClearText()
        {
            TextBox3.Text = String.Empty;
            TextBox4.Text = String.Empty;
            TextBox5.Text = String.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string em, pass;
            em = TextBox1.Text;
            pass = TextBox2.Text;
            string q = "exec UserLoginproc '" + em + "','" + pass + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (rdr["user_email"].Equals(em) && rdr["user_pass"].Equals(pass) && rdr["user_role"].Equals("Admin"))
                    {
                        Session["MyUser"] = em;
                        Response.Redirect("HR.aspx");
                    }

                    if (rdr["user_email"].Equals(em) && rdr["user_pass"].Equals(pass) && rdr["user_role"].Equals("User"))
                    {
                        Session["MyUser"] = em;
                        Response.Redirect("User.aspx");
                    }
                }

            }
            else
            {

                Response.Write("<script>alert('Invalid user email or password')</script>");

            }

        }
    }
}