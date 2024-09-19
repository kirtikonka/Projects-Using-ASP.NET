using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBCONN
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(string to, string subject, string body)
        {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("kirtikonka0506@gmail.com");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;

                // Handle file attachments
                if (fileUpload1.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in fileUpload1.PostedFiles)
                    {
                        Attachment attachment = new Attachment(uploadedFile.InputStream, uploadedFile.FileName);
                        mail.Attachments.Add(attachment);
                    }
                }

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("kirtikonka0506@gmail.com", "woknrxxrwzhenmxw");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                Response.Write("<script>alert('Email Sent Successfully')</script>");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
                string to, subject, body;
                to = TextBox1.Text;
                subject = TextBox2.Text;
                body = TextBox3.Text;
                btnSubmit_Click(to, subject, body);
        }
    }
}