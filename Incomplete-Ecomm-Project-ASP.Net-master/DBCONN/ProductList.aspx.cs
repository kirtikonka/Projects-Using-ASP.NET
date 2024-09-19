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
    public partial class ProductList : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            FetchProducts();
        }

        public void FetchProducts()
        {
            string q = "select * from Product_Table";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader r = cmd.ExecuteReader();
            DataList1.DataSource = r;
            DataList1.DataBind();
        }
        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}