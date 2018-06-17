// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SendGrid;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents the email service used by <see cref="UserManager"/> for sending emails to users.
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        private const string SEND_GRID_API_KEY_NAME = "sendGrid:apiKey";
        private const string SEND_GRID_FROM_EMAIL_SENDER = "sendGrid:fromEmailAddress";
        /// <summary>
        /// Asynschronously sends an email to a user.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public async Task SendAsync(IdentityMessage message)
        {
            string emailServiceApiKey = "";

            if(ConfigurationManager.AppSettings.AllKeys.Contains(SEND_GRID_API_KEY_NAME))
            {
                emailServiceApiKey = ConfigurationManager.AppSettings[SEND_GRID_API_KEY_NAME];
            }

            if(string.IsNullOrEmpty(emailServiceApiKey))
            {
                throw new InvalidOperationException(string.Format("{0} is not provided under appSettings in the application configuration file.", SEND_GRID_API_KEY_NAME));
            }

            string fromEmailAddress = "noreply@devaccelerate.com";

            if (ConfigurationManager.AppSettings.AllKeys.Contains(SEND_GRID_FROM_EMAIL_SENDER))
            {
                fromEmailAddress = ConfigurationManager.AppSettings[SEND_GRID_FROM_EMAIL_SENDER];
            }

            var oclient = new SendGridClient(emailServiceApiKey);

            var sgMessage = new SendGrid.Helpers.Mail.SendGridMessage()
            {
                From = new SendGrid.Helpers.Mail.EmailAddress()
                {
                    Email = fromEmailAddress
                },
                Subject = message.Subject,
                HtmlContent = message.Body
            };

            sgMessage.AddTo(message.Destination);

            await oclient.SendEmailAsync(sgMessage);
        }
    }
}
