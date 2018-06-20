// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    public class DaProviderConfigurationSection
        : DaProviderConfigurationSection<ProviderConfigurationElement>
    {
    }

    public class DaProviderConfigurationSection<TProviderConfigurationElement> : DaConfigurationSection
        where TProviderConfigurationElement : ProviderConfigurationElement
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
        public ProviderConfigurationElementCollection<TProviderConfigurationElement> Providers
        {
            get
            {
                return this[PROVIDERS] as ProviderConfigurationElementCollection<TProviderConfigurationElement>;
            }
            set
            {
                this[PROVIDERS] = value;
            }
        }
    }
}
