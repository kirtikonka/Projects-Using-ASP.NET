using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DBCONN
{
    public partial class AddProduct : System.Web.UI.Page
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
            string pname = TextBox1.Text, pcatagory = DropDownList1.SelectedValue,pimg;
            double price = double.Parse(TextBox2.Text);

            FileUpload1.SaveAs(Server.MapPath("Images/") + Path.GetFileName(FileUpload1.FileName));
            pimg="Images/"+Path.GetFileName(FileUpload1.FileName);

            string q = $"exec AddToProduct '{pname}','{pcatagory}','{price}','{pimg}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Product added successfully!');</script>");

        }
    }
}