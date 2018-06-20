// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Sms;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents the SMS service used by the <see cref="UserManager"/> to send SMS messages to users.
    /// </summary>
    public class SmsService : IIdentityMessageService
    {
        /// <summary>
        /// Asynchronously sends an SMS message to a user.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public Task SendAsync(IdentityMessage message)
        {
            var smsProvider = SmsProviderFactory.GetProvider();
            return smsProvider.SendAsync(message.Destination, message.Body);
        }
    }
}
