// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Mail
{
    public static class MailConfigurationManager
    {
        private const string MAIL_CONFIG = "daMailConfiguration";

        public static void SetConfiguration(IConfigurationSource configurationSource)
        {
            DaApplicationContext.SetupConfiguration<ProviderConfigurationSection>(MAIL_CONFIG, configurationSource);
        }

        public static MailConfigurationSection GetConfiguration()
        {
            return DaApplicationContext.GetConfiguration<MailConfigurationSection>(MAIL_CONFIG);
        }
    }
}
