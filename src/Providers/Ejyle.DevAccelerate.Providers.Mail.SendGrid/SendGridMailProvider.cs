using Ejyle.DevAccelerate.Core.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SG = SendGrid;

namespace Ejyle.DevAccelerate.Providers.Mail.SendGrid
{
    public class SendGridMailProvider : MailProviderBase
    {
        public override void Send(string to, string from, string subject, string body)
        {
            throw new NotSupportedException();
        }

        public override void Send(MailMessage message)
        {
            throw new NotSupportedException();
        }

        public override async Task SendAsync(MailMessage message)
        {
            var oclient = new SG.SendGridClient(SmtpServer.ApiKey);

            var sgMessage = new SG.Helpers.Mail.SendGridMessage()
            {
                From = new SG.Helpers.Mail.EmailAddress()
                {
                    Email = DefaultFromEmail
                },
                Subject = message.Subject,
                HtmlContent = message.Body
            };

            foreach(var to in message.To)
            {
                sgMessage.AddTo(to.Address, to.DisplayName);
            }

            await oclient.SendEmailAsync(sgMessage);
        }

        public override Task SendAsync(string to, string from, string subject, string body)
        {
            return SendAsync(new MailMessage(from, to)
            {
                Subject = subject,
                Body = body
            });
        }
    }
}
