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
    public partial class AddProducts : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
        }
        /*
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string pname, pcat, pic;
            double price;

            pname = TextBox1.Text;
            pcat = DropDownList1.SelectedValue;

            FileUpload1.SaveAs(System.Web.HttpContext.Current.Server.MapPath("Products/") + Path.GetFileName(FileUpload1.FileName));
            pic = "Profiles/" + Path.GetFileName(FileUpload1.FileName);

            string q = "exec AddProductProc '" + pname + "','" + pcat + "','" + pic + "','" + price + "','" + pdesc + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Product Added Successfully!');</script>");

            string pdesc;

            pdesc = TextBox4.Text;
            price = double.Parse(TextBox3.Text);
        }
       */
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string pname, pcat, pic,pdesc;
            double price; // Declare price before using it

            pname = TextBox1.Text;
            pcat = DropDownList1.SelectedValue;

            FileUpload1.SaveAs(System.Web.HttpContext.Current.Server.MapPath("Products/") + Path.GetFileName(FileUpload1.FileName));
            pic = "Profiles/" + Path.GetFileName(FileUpload1.FileName);

            price = double.Parse(TextBox3.Text); // Assign value to price after declaration
            pdesc = TextBox4.Text;

            string q = "exec AddProductProc '" + pname + "','" + pcat + "','" + pic + "','" + price + "','" + pdesc + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Product Added Successfully!');</script>");

            
        }

    }
}