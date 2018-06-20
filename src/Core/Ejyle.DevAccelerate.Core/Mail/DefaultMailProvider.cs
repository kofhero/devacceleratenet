// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Net.Mail;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core.Mail
{
    public class DefaultMailProvider : MailProviderBase
    {
        public DefaultMailProvider() : base()
        { }

        public override void Send(MailMessage mail)
        {
            var smtpClient = new SmtpClient(this.SmtpServer.Host);

            smtpClient.Port = (int)SmtpServer.Port;
            smtpClient.Credentials = new System.Net.NetworkCredential(SmtpServer.UserId, SmtpServer.Password);
            smtpClient.EnableSsl = SmtpServer.UseSsl;

            smtpClient.Send(mail);
        }

        public override void Send(string to, string from, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };

            Send(message);
        }

        public override Task SendAsync(MailMessage message)
        {
            var smtpClient = new SmtpClient(SmtpServer.Host);

            smtpClient.Port = (int)SmtpServer.Port;
            smtpClient.Credentials = new System.Net.NetworkCredential(SmtpServer.UserId, SmtpServer.Password);
            smtpClient.EnableSsl = SmtpServer.UseSsl;

            return smtpClient.SendMailAsync(message);
        }

        public override Task SendAsync(string to, string from, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };

            return SendAsync(message);
        }
    }
}
