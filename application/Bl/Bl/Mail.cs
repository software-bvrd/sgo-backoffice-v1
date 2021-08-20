using System;
using System.Net.Mail;

namespace Bl.Bl
{
    class Mail
    {
        public void SendMail(string from, string to, string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("roman.rodriguez", "Password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception )
            {
                throw;
            }
        }


    }
}
