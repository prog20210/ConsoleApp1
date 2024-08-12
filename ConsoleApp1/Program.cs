using System;
using System.Net.Mail;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailCredentials credentials = new EmailCredentials();
           
            credentials.Domain = "yandex.ru";
            credentials.SMTPUser = "avsemykin2016@yandex.ru";
            credentials.SMTPPassword = "avs0187";
            int SmtpPort = 465;
            string SmtpServer = "smtp.yandex.com";
            string senderMail = "avsemykin2016@yandex.ru";
            string senderName = "tp";


            System.Net.Mail.MailAddress sender = new System.Net.Mail.MailAddress(senderMail, senderName, System.Text.Encoding.UTF8);

            System.Net.Mail.MailAddress recipient = new System.Net.Mail.MailAddress(recipientEmail, recipientName, System.Text.Encoding.UTF8);

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage(sender, recipient);

            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.SubjectEncoding = System.Text.Encoding.UTF8;

            System.Net.Mail.AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(mailBody, @"<(.|\n)*?>", string.Empty), null, MediaTypeNames.Text.Plain);

            System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(mailBody, null, MediaTypeNames.Text.Html);

            email.AlternateViews.Clear();
            email.AlternateViews.Add(plainView);
            email.AlternateViews.Add(htmlView);
            email.Subject = mailTitle;

            System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient();
            SMTP.Host = SmtpServer;
            SMTP.Port = SmtpPort;
            SMTP.EnableSsl = true;
            SMTP.Credentials = new System.Net.NetworkCredential(credentials.SMTPUser, credentials.SMTPPassword);

            SMTP.Send(email);

        }
    }
}
