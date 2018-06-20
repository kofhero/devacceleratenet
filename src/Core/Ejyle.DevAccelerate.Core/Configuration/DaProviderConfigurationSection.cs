// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    public class DaProviderConfigurationSection : DaConfigurationSection
    {
        private const string PROVIDERS = "providers";
        private const string DEFAULT_PROVIDER = "defaultProvider";

        [ConfigurationProperty(DEFAULT_PROVIDER, IsRequired = false, DefaultValue = null)]
        public string DefaultProvider
        {
            get
            {
                return this[DEFAULT_PROVIDER] as string;
            }
            set
            {
                this[DEFAULT_PROVIDER] = value;
            }
        }

        [ConfigurationProperty(PROVIDERS, IsRequired = false, DefaultValue = null)]
        public ProviderConfigurationElementCollection Providers
        {
            get
            {
                return this[PROVIDERS] as ProviderConfigurationElementCollection;
            }
            set
            {
                this[PROVIDERS] = value;
            }
        }
    }
}
