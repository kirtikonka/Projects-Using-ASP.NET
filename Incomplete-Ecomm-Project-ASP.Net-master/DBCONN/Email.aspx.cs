using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBCONN
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void sendMail(string to, string subject, string body, string file)
        {
            MailMessage mail = new MailMessage();
            mail.From=new MailAddress("kirtikonka0506@gmail.com");
            mail.To.Add(to);
            mail.Subject=subject;
            mail.Body=body;
            mail.File = file;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("kirtikonka0506@gmail.com", "woknrxxrwzhenmxw");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            Response.Write("<script>alert('Email Sent Successfully')</script>");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string to, subject, body, file;
            to = TextBox1.Text;
            subject = TextBox2.Text;
            body = TextBox3.Text;
            file = FileUpload1.;
            sendMail(to, subject, body, file);
        }
    }
}