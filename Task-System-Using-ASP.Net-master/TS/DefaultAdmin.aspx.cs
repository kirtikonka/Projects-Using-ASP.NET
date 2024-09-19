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
    public partial class DefaultAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (Session["myuser"] != null)
            {
                string email = (Session["myuser"].ToString());
                string q = " select * from users where email='" + email + "'";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                string user = rdr["fname"].ToString();
                Label1.Text = user;
            }
            else
            {
                Response.Write("<script>alert('You need to login again');window.location.href='Login.aspx'</script>");
            }
        }
    }
}