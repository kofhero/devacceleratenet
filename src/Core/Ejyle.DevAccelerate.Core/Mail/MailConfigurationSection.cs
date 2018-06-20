// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Mail
{
    public class MailConfigurationSection : DaProviderConfigurationSection
    {
        private const string SMTP_SERVER = "smtpServer";

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
