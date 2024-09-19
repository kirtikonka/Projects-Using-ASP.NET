using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TS
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string em, pass;
            em = TextBox1.Text;
            pass = TextBox2.Text;

            string q = "exec userloginproc '" + em + "','" + pass + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (rdr["email"].Equals(em) && rdr["password"].Equals(pass) && rdr["profile"].Equals("admin"))
                    {
                        Session["myuser"] = em;
                        Response.Redirect("DefaultAdmin.aspx");

                    }
                    if (rdr["email"].Equals(em) && rdr["password"].Equals(pass) && rdr["profile"].Equals("user"))
                    {
                        Session["myuser"] = em;
                        Response.Redirect("DefaultUser.aspx");

                    }
                }
            }
            else
            {
                Response.Write("<script>alert(Invalid Email or Password is incorrect!);</script>");
            }
        }
    }
}