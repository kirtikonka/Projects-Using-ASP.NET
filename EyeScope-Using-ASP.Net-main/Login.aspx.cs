using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    //Step 5: Create SQl connection
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
        }

        //Step 6: create a table and a procedure of User Account in sql server, 
        protected void Button2_Click(object sender, EventArgs e)
        {
            //Register
            string user, pass, em, role="User", profile;
            user = TextBox5.Text;
            pass= TextBox4.Text;
            em= TextBox3.Text;
            
            //file upload while register

            //FileUpload1.SaveAs(Server.MapPath("Profiles/") + Path.GetFileName(FileUpload1.FileName));
            FileUpload1.SaveAs(System.Web.HttpContext.Current.Server.MapPath("Profiles/") + Path.GetFileName(FileUpload1.FileName));
            profile = "Profiles/" + Path.GetFileName(FileUpload1.FileName);      

            //check exisiting user
            string q1 = "exec UserExistProc '"+user+"','"+em+"'";
            SqlCommand cmd1 = new SqlCommand(q1, conn);
            SqlDataReader r = cmd1.ExecuteReader();
            if(r.HasRows)
            {
                Response.Write("<script>alert('Username or EmailID already exisits!');</script>");
            }
            else
            {
                //new user
                string q = "exec NewUserAccountProc '" + user + "','" + pass + "','" + em + "','" + role + "','" + profile + "'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                clear();
                Response.Write("<script>alert('Registeration Successful!');</script>");

            }

        }

        //clear once registeration is successful
        protected void clear()
        {
            TextBox5.Text = "";
            TextBox4.Text = "";
            TextBox3.Text = "";
        }

        //Login Button Redirecting according to User and Admin
        
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string em, pass;
            em = TextBox1.Text;
            pass = TextBox2.Text;

            string q = "exec UserLoginProc '" + em + "','" + pass + "' ";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (rdr["acc_email"].Equals(em) && rdr["acc_pass"].Equals(pass) && rdr["acc_role"].Equals("Admin"))//'Admin'
                    {
                        Session["MyUser"] = em;
                        Response.Redirect("AddProducts.aspx");
                    }
                    if (rdr["acc_email"].Equals(em) && rdr["acc_pass"].Equals(pass) && rdr["acc_role"].Equals("User"))//'User'
                    {
                        Session["MyUser"] = em;
                        Response.Redirect("Home.aspx");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Email or Password');</script>");
            }
        }
    }
}