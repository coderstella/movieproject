using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using movieproject.Dtos.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace movieproject.Areas.Identity.Extention
{
    public class CustomEmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public CustomEmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // forward email code goes here
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_emailSettings.RegisterVarificationEmail.NoReplyEmail));
                message.To.Add(new MailboxAddress(email));
                message.Subject = subject;

                message.Body = new TextPart("plain")
                {
                    Text = htmlMessage
                };

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect(_emailSettings.RegisterVarificationEmail.ServerName, _emailSettings.RegisterVarificationEmail.ServerPort, true);
                    smtpClient.Authenticate(new NetworkCredential(_emailSettings.RegisterVarificationEmail.EmailUser, _emailSettings.RegisterVarificationEmail.EmailPassword));
                    smtpClient.Send(message);
                    smtpClient.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
