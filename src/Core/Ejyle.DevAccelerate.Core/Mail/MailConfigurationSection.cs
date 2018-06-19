// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Mail
{
    public class MailConfigurationSection : DaConfigurationSection
    {
        private const string SMTP_SERVER = "smtpServer";
        private const string MAIL_PROVIDER = "mailProvider";

        [ConfigurationProperty(MAIL_PROVIDER, IsRequired = false)]
        public ProviderConfigurationElement MailProvider
        {
            get
            {
                return this[MAIL_PROVIDER] as ProviderConfigurationElement;
            }
            set
            {
                this[MAIL_PROVIDER] = value;
            }
        }

        [ConfigurationProperty(SMTP_SERVER, IsRequired = false)]
        public SmtpServerConfigurationElement SmtpServer
        {
            get
            {
                return this[SMTP_SERVER] as SmtpServerConfigurationElement;
            }
            set
            {
                this[SMTP_SERVER] = value;
            }
        }

        public override string GetConfigurationSectionName()
        {
            return "daMailConfiguration";
        }
    }
}
