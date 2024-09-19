using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (Session["MyUser"]!=null)
            {
                string user_email = Session["MyUser"].ToString();
                string q = "select * from user_account where acc_email = '"+user_email+"";
                SqlCommand cmd = new SqlCommand(q,conn);
                SqlDataReader rdr=cmd.ExecuteReader();
                rdr.Read();
                string user = rdr["acc_user"].ToString();
                Label1.Text = user;
            }
            else
            {
                Response.Redirect("<script>alert('You need to Login!');window.location.href='Login.aspx';</script>");
            }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}