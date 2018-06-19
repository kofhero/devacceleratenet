// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Notifications.Configuration
{
    public class NotificationConfigurationSection : DaConfigurationSection
    {
        private const string EMAIL_PROVIDER = "emailProvider";
        private const string SMS_PROVIDER = "smsProvider";   

        [ConfigurationProperty(EMAIL_PROVIDER, IsRequired = false)]
        public EmailProviderConfigurationElement EmailProvider
        {
            get
            {
                return this[EMAIL_PROVIDER] as EmailProviderConfigurationElement;
            }
            set
            {
                this[EMAIL_PROVIDER] = value;
            }
        }

        [ConfigurationProperty(SMS_PROVIDER, IsRequired = false)]
        public SmsProviderConfigurationElement SmsProvider
        {
            get
            {
                return this[SMS_PROVIDER] as SmsProviderConfigurationElement;
            }
            set
            {
                this[SMS_PROVIDER] = value;
            }
        }

        public override string GetConfigurationSectionName()
        {
            return "daNotificationConfiguration";
        }
    }
}
