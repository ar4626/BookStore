using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Common_Layer.Utility
{
    public class Mail
    {
        public string SendMail(string ToEmail, string Token)
        {
            string FromEmail = "ar2646@srmist.edu.in";
            MailMessage Message = new MailMessage(FromEmail, ToEmail);
            //string MailBody = "Token Generated : " + Token;
            string MailBody = $"FundooNotes Reset Password : <a href=http://localhost:4200/reset-password/{Token}> Click Me </a>";
            Message.Subject = "FundoNotes Rest Password Link";
            Message.Body = MailBody.ToString();
            Message.BodyEncoding = Encoding.UTF8;
            Message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential credential
                = new NetworkCredential(FromEmail, "ckvc cppd gulr nfyd");

            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;

            smtp.Send(Message);
            return ToEmail;
        }
    }
}
