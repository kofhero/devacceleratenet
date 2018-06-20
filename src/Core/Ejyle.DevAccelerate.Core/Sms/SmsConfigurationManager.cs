// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Sms
{
    public static class SmsConfigurationManager
    {
        private const string SMS_CONFIG = "daSmsConfiguration";

        public static void SetConfiguration(IConfigurationSource configurationSource)
        {
            DaApplicationContext.SetupConfiguration<SmsConfigurationSection>(SMS_CONFIG, configurationSource);
        }

        public static SmsConfigurationSection GetConfiguration()
        {
            return DaApplicationContext.GetConfiguration<SmsConfigurationSection>(SMS_CONFIG);
        }
    }
}
