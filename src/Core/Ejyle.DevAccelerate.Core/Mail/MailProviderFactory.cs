// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Configuration;
using System;

namespace Ejyle.DevAccelerate.Core.Mail
{
    public static class MailProviderFactory
    {
        public static IMailProvider GetProvider()
        {
            ProviderConfigurationElement providerConfig = null;

            var config = MailConfigurationManager.GetConfiguration();

            if (config != null)
            {
                providerConfig = config.MailProvider;
            }

            if (providerConfig == null)
            {
                return new DefaultMailProvider();
            }

            var type = Type.GetType(providerConfig.Type);
            return Activator.CreateInstance(type) as IMailProvider;
        }
    }
}
