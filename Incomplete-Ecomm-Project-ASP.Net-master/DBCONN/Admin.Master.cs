using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace DBCONN
{
    
    public partial class Site1 : System.Web.UI.MasterPage
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (Session["myuser"]!=null)
            {
                string semail = (Session["myuser"].ToString());
                string q = $"select * from auth where email='{semail}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                Label1.Text = rdr["username"].ToString();
            }
            else
            {
                Response.Write("<script>alert('You need to login!);window.location.href='Login.aspx';</script>");
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}