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
    public partial class UserList : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                FetchUserList();
            }
        }

        protected void FetchUserList()
        {
            string q = "exec UserListProc";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
        }
/*
        protected void GridView1_RowDeleting(object sender, GridViewDeletedEventArgs e)
        {
            Label lbl = (Label)GridView1.Rows[e.RowIndex].FindControl("Label1");
            string id = lbl.Text;

            string q = "exec DeleteAccountByID '"+id+"'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            FetchUserList();
        }
*/
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Use GridViewDeleteEventArgs for RowDeleting event

            int rowIndex = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value); // Use DataKeys

            string id = "";

            // Check if DataKeys are available (recommended)
            if (GridView1.DataKeys != null)
            {
                id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            }
            else // If DataKeys not available, try finding Label1 within the row
            {
                Label lbl = (Label)GridView1.Rows[e.RowIndex].FindControl("Label1");
                if (lbl != null)
                {
                    id = lbl.Text;
                }
            }

            if (!string.IsNullOrEmpty(id))
            {
                string q = "exec DeleteAccountByID '" + id + "'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                FetchUserList();
            }
            else
            {
                // Handle case where ID cannot be retrieved (log error, display message)
            }
        }

    }
}