using System;
using System.Net;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Net.Mail;


namespace ClassLibrary
{
    public class Email
    {
        string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection();

        public bool SendEmail(string Sender, string Receiver, string Sub, string Body)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(Receiver);
            mail.From = new MailAddress(Sender);
            mail.Subject = Sub;
            mail.Body = Body;
            SmtpClient sc = new SmtpClient("mail.slri.or.th");
            sc.Send(mail);


            return true;
        }

        public bool SendEmailHTML_Format(string Sender, string Receiver, string Sub, string Body)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.To.Add(Receiver);
            mail.From = new MailAddress(Sender);
            mail.Subject = Sub;
            mail.Body = "<html>" + Body + "</html>";

            mail.BodyEncoding = Encoding.UTF8;

            SmtpClient sc = new SmtpClient("mail.slri.or.th");
            sc.Send(mail);

            return true;
        }

        //public bool SendEmailWithAttachFile(string Sender, string Receiver, string Sub, string Body, string[] filename)
        //{
        //    MailMessage mail = new MailMessage();
        //    mail.BodyFormat = MailFormat.Html;
        //    mail.To = Receiver;
        //    mail.From = Sender;
        //    mail.Subject = Sub;
        //    mail.Body = Body;

        //    for (int i = 0; i < filename.GetLength(0); i++)
        //    {
        //        MailAttachment Att = new MailAttachment(".\\UploadFile\\" + filename[i]);
        //        mail.Attachments.Add(Att);
        //    }

        //    SmtpMail.SmtpServer = "10.8.99.81";
        //    SmtpMail.Send(mail);

        //    return true;
        //}
    }
}
