// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.Mail;
using Microsoft.AspNet.Identity;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents the email service used by <see cref="UserManager"/> for sending emails to users.
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        /// <summary>
        /// Asynschronously sends an email to a user.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public Task SendAsync(IdentityMessage message)
        {
            var mailProvider = MailProviderFactory.GetProvider();
            var mail = new MailMessage();
            mail.To.Add(message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;

            return mailProvider.SendAsync(mail);
        }
    }
}
