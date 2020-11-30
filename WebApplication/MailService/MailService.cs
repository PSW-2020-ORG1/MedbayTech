using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.MailService
{
    public class MailService : IMailService
    {

        private readonly MailSettings mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            this.mailSettings = mailSettings.Value;
        }
        public async Task SendMailAsync(MailRequest mailRequest)
        {

            string FilePath = Directory.GetCurrentDirectory() + "\\MailService\\MailTemplate\\ConfirmationMailTemplate.html";
            StreamReader streamReader = new StreamReader(FilePath);
            string mailText = streamReader.ReadToEnd();
            streamReader.Close();

            mailText = mailText.Replace("[username]", mailRequest.Body).Replace("[link]", mailRequest.Url).Replace("[email]", mailRequest.ToEmail);
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = $"Welcome {mailRequest.ToEmail}";
            var builder = new BodyBuilder();
            builder.HtmlBody = mailText;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
    }
}
