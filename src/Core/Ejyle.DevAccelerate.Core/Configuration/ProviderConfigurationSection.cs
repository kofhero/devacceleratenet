// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Defines the properties for a provider configuration.
    /// </summary>
    public class ProviderConfigurationSection : DaConfigurationSection
    {
        private const string EXTENDED_PROPERTIES = "extendedProperties";
        private const string TYPE = "type";

        /// <summary>
        /// Gets or sets the type of the provider.
        /// </summary>
        [ConfigurationProperty(TYPE, IsRequired = true)]
        public string Type
        {
            get
            {
                return this[TYPE] as string;
            }
            set
            {
                this[TYPE] = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of extended properties for the provider configuration section.
        /// </summary>
        [ConfigurationProperty(EXTENDED_PROPERTIES)]
        public ExtendedPropertyConfigurationElementCollection ExtendedProperties
        {
            get
            {
                return this[EXTENDED_PROPERTIES] as ExtendedPropertyConfigurationElementCollection;
            }
            set
            {
                this[EXTENDED_PROPERTIES] = value;
            }
        }
    }
}
