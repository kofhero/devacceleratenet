// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents the SMS service used by the <see cref="UserManager"/> to send SMS messages to users.
    /// </summary>
    public class SmsService : IIdentityMessageService
    {
        private const string TWILIO_ACCOUNT_SID_NAME = "twilio:accountSid";
        private const string TWILIO_AUTH_TOKEN_NAME = "twilio:authToken";
        private const string TWILIO_FROM_PHONE_NUMBER = "twilio:fromPhoneNumber";

        /// <summary>
        /// Asynchronously sends an SMS message to a user.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public async Task SendAsync(IdentityMessage message)
        {
            string accountSid = "";

            if (ConfigurationManager.AppSettings.AllKeys.Contains(TWILIO_ACCOUNT_SID_NAME))
            {
                accountSid = ConfigurationManager.AppSettings[TWILIO_ACCOUNT_SID_NAME];
            }

            if (string.IsNullOrEmpty(accountSid))
            {
                throw new InvalidOperationException(string.Format("{0} is not provided under appSettings in the application configuration file.", TWILIO_ACCOUNT_SID_NAME));
            }


            string authToken = "";

            if (ConfigurationManager.AppSettings.AllKeys.Contains(TWILIO_AUTH_TOKEN_NAME))
            {
                authToken = ConfigurationManager.AppSettings[TWILIO_AUTH_TOKEN_NAME];
            }

            if (string.IsNullOrEmpty(authToken))
            {
                throw new InvalidOperationException(string.Format("{0} is not provided under appSettings in the application configuration file.", TWILIO_AUTH_TOKEN_NAME));
            }


            string fromPhoneNumber = "";

            if (ConfigurationManager.AppSettings.AllKeys.Contains(TWILIO_FROM_PHONE_NUMBER))
            {
                fromPhoneNumber = ConfigurationManager.AppSettings[TWILIO_FROM_PHONE_NUMBER];
            }

            if (string.IsNullOrEmpty(fromPhoneNumber))
            {
                throw new InvalidOperationException(string.Format("{0} is not provided under appSettings in the application configuration file.", TWILIO_FROM_PHONE_NUMBER));
            }

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(message.Destination);
            var msg = await MessageResource.CreateAsync(to, from: new PhoneNumber(fromPhoneNumber),body: message.Body);

            Console.WriteLine(msg.Sid);
        }
    }
}
