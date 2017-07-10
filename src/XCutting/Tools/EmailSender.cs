using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssuesManager.Tools
{
    public class EmailService : IEmailService
    { 

        public EmailService () { }

        ///
        /// Sends an Email asynchronously
        ///
        public async Task SendAsync(string To, string subject, string body)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("IssuesManagerInfo", "info@issuesmanager.com"));
            emailMessage.To.Add(new MailboxAddress("", To));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                client.LocalDomain = "some.domain.com";
                await client.ConnectAsync("localhost", 25, SecureSocketOptions.None).ConfigureAwait(false);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}
