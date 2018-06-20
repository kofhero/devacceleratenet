// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Sms
{
    public class SmsConfigurationSection
        : DaProviderConfigurationSection<SmsProviderConfigurationElement>
    {
        public override string GetConfigurationSectionName()
        {
            return "daSmsConfiguration";
        }
    }
}
