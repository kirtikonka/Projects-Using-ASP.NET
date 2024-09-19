using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payslip
{
    public partial class ApplyLeave : System.Web.UI.Page
    {

        SqlConnection conn;
        int p, c, s;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
            get();
        }
        protected void get()
        {
            string q = $"select * from Leave where EmpId=1";   //changes
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                p = int.Parse(r["pl"].ToString());
                c = int.Parse(r["cl"].ToString());
                s = int.Parse(r["sl"].ToString());

                Label1.Text = p.ToString();
                Label2.Text = c.ToString();
                Label3.Text = s.ToString();
            }
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {

            //string leaveType = DropDownList1.SelectedItem.Text;
            DateTime s1 = DateTime.Parse(TextBox1.Text);
            DateTime s2 = DateTime.Parse(TextBox2.Text);
            //   string s2 = TextBox2.Text;

            int d = (s2 - s1).Days + 1;
            //Label3.Text = d.ToString();
            if (DropDownList1.SelectedValue == "pl")
            {
                if (d < p)
                {
                    p = p - d;
                    string q1 = $"update Leave set pl='{p}' where Empid=1"; //change
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("ApplyLeave.aspx");
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (p + c >= d)
                {
                    int temp = d - p;
                    int temp2 = c - temp;
                    string q1 = $"update Leave set pl=0,cl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (p + s >= d)
                {
                    int temp = d - p;
                    int temp2 = s - temp;
                    string q1 = $"update Leave set pl=0,sl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (c + s >= d)
                {
                    int temp = d - c;
                    int temp2 = s - temp;
                    string q1 = $"update Leave set cl=0,sl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (p + c + s >= d)
                {
                    int temp = d - p;
                    int temp2 = c - temp;
                    int temp3 = s - temp2;
                    string q1 = $"update Leave set pl=0,cl=0,sl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else
                {
                    int temp = p + c + s;
                    int temp2 = d - temp;
                    string q1 = $"update Leave set pl=0,cl=0,sl=0,Extra='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                Response.Redirect("Index.aspx");
            }
            else if (DropDownList1.SelectedValue == "cl")
            {
                if (d < c)
                {
                    c = c - d;
                    string q1 = $"update Leave set cl='{c}'  where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (p + c >= d)
                {
                    int temp = d - p;
                    int temp2 = c - temp;
                    string q1 = $"update Leave set pl=0,cl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (p + s >= d)
                {
                    int temp = d - p;
                    int temp2 = s - temp;
                    string q1 = $"update Leave set pl=0,sl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (c + s >= d)
                {
                    int temp = d - c;
                    int temp2 = s - temp;
                    string q1 = $"update Leave set cl=0,sl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (p + c + s >= d)
                {
                    int temp = d - p;
                    int temp2 = c - temp;
                    int temp3 = s - temp2;
                    string q1 = $"update Leave set pl=0,cl=0,sl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else
                {
                    int temp = p + c + s;
                    int temp2 = d - temp;
                    string q1 = $"update Leave set pl=0,cl=0,sl=0,Extra='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                Response.Redirect("Index.aspx");
            }
            else if (DropDownList1.SelectedValue == "sl")
            {
                if (d < s)
                {
                    s = s - d;
                    string q1 = $"update Leave set sl='{s}'  where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (p + c >= d)
                {
                    int temp = d - p;
                    int temp2 = c - temp;
                    string q1 = $"update Leave set pl=0,cl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (p + s >= d)
                {
                    int temp = d - p;
                    int temp2 = s - temp;
                    string q1 = $"update Leave set pl=0,sl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (c + s >= d)
                {
                    int temp = d - c;
                    int temp2 = s - temp;
                    string q1 = $"update Leave set cl=0,sl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else if (p + c + s >= d)
                {
                    int temp = d - p;
                    int temp2 = c - temp;
                    int temp3 = s - temp2;
                    string q1 = $"update Leave set pl=0,cl=0,sl='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                else
                {
                    int temp = p + c + s;
                    int temp2 = d - temp;
                    string q1 = $"update Leave set pl=0,cl=0,sl=0,Extra='{temp2}' where Empid=1";
                    SqlCommand cmd = new SqlCommand(q1, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Applied Successfully')</script>");
                }
                Response.Redirect("Index.aspx");
            }


            //Default values in labels to be mentioned
            //As soon as apply values should be deducted from labels

        }
    }
}
