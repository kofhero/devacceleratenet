// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Mail
{
    public class MailConfigurationSection : DaProviderConfigurationSection<MailProviderConfigurationElement>
    {
        private const string DEFAULT_SENDER_NAME = "defaultSenderName";
        private const string DEFAULT_SENDER_EMAIL = "defaultSenderEmail";

        [ConfigurationProperty(DEFAULT_SENDER_NAME, IsRequired = false, DefaultValue = "DevAccelerate")]
        public string DefaultSenderName
        {
            get
            {
                return this[DEFAULT_SENDER_NAME] as string;
            }
            set
            {
                this[DEFAULT_SENDER_NAME] = value;
            }
        }

        [ConfigurationProperty(DEFAULT_SENDER_EMAIL, IsRequired = false, DefaultValue = "email@devaccelerate.com")]
        public string DefaultSenderEmail
        {
            get
            {
                return this[DEFAULT_SENDER_EMAIL] as string;
            }
            set
            {
                this[DEFAULT_SENDER_EMAIL] = value;
            }
        }

        public override string GetConfigurationSectionName()
        {
            return "daMailConfiguration";
        }
    }
}
