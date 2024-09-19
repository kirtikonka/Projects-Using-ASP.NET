using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payslip
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
        protected void Button3_Click(object sender, EventArgs e)
        {
            string fname, lname, email, pass, role = "User", profile;
            //long mobile;
            fname = TextBox3.Text;
            lname = TextBox4.Text;
            email = TextBox6.Text;
            pass = TextBox7.Text;
            if (!long.TryParse(TextBox5.Text, out long mobile))
            {
                Response.Write("<script>alert('Invalid mobile number. Please enter a valid number.')</script>");
                return;
            }

            FileUpload1.SaveAs(Server.MapPath("profile/") + Path.GetFileName(FileUpload1.FileName));
            profile = "profile/" + Path.GetFileName(FileUpload1.FileName);

            string q1 = "exec UserExistproc '" + fname + "','" + email + "'";
            SqlCommand c1 = new SqlCommand(q1, conn);
            SqlDataReader r = c1.ExecuteReader();
            if (r.HasRows)
            {
                Response.Write("<script>alert('username and email already exist.')</script>");
            }
            else
            {
                string q = "exec New_User_accountproc '" + fname + "','" + lname + "','" + mobile + "','" + email + "','" + pass + "','" + role + "','" + profile + "'";
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
            TextBox6.Text = String.Empty;
            TextBox7.Text = String.Empty;

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
                        Response.Redirect("AddProducts.aspx");
                    }

                    if (rdr["user_email"].Equals(em) && rdr["user_pass"].Equals(pass) && rdr["user_role"].Equals("User"))
                    {
                        Session["MyUser"] = em;
                        Response.Redirect("UserHome.aspx");
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