// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core.Mail
{
    public class DefaultMailProvider : IMailProvider
    {
        private SmtpServerConfigurationElement _config;

        public DefaultMailProvider()
        {
            _config = MailConfigurationManager.GetConfiguration().SmtpServer;
        }

        public void Send(MailMessage mail)
        {
            var smtpClient = new SmtpClient(_config.HostName);

            smtpClient.Port = _config.Port;
            smtpClient.Credentials = new System.Net.NetworkCredential(_config.UserId, _config.Password);
            smtpClient.EnableSsl = _config.UseSsl;

            smtpClient.Send(mail);
        }

        public void Send(string to, string from, string subject, string body)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };

            Send(message);
        }

        public Task SendAsync(MailMessage message)
        {
            var smtpClient = new SmtpClient(_config.HostName);

            smtpClient.Port = _config.Port;
            smtpClient.Credentials = new System.Net.NetworkCredential(_config.UserId, _config.Password);
            smtpClient.EnableSsl = _config.UseSsl;

            return smtpClient.SendMailAsync(message);
        }

        public Task SendAsync(string to, string from, string subject, string body)
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
