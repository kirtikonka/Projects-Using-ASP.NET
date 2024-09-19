using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _21June2024_WebFormProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string pname, pcatagory, pimg;
            double price;
            pname= ProductNameID.Text;
            pcatagory= ListProductCatID.SelectedValue;
            price= double.Parse(ProductPriceID.Text);

            FileUploadProductImgID.SaveAs(Server.MapPath("Images/" + Path.GetFileName(FileUploadProductImgID.FileName)));
            pimg = "Images/" + Path.GetFileName(FileUploadProductImgID.FileName);

            string q = $"exec AddProductProc '{pname}','{pcatagory}','{pimg}','{price}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Product Added Successfully')</script>");
        }
    }
}