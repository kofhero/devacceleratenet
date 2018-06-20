// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Configuration;
using System;

namespace Ejyle.DevAccelerate.Core.Sms
{
    public static class SmsProviderFactory
    {
        public static ISmsProvider GetProvider()
        {
            ProviderConfigurationElement providerConfig = null;

            var config = SmsConfigurationManager.GetConfiguration();

            if (config != null)
            {
                providerConfig = config.Providers.GetByName(config.DefaultProvider);
            }

            if (providerConfig == null)
            {
                return null;
            }

            var type = Type.GetType(providerConfig.Type);
            return Activator.CreateInstance(type) as ISmsProvider;
        }
    }
}
