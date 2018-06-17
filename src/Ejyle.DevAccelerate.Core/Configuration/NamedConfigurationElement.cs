// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Represents a named property for a provider configuration.
    /// </summary>
    public class NamedConfigurationElement : ConfigurationElement
    {
        private const string NAME = "name";

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        [ConfigurationProperty(NAME, IsRequired = true)]
        public string Name
        {
            get
            {
                return this[NAME] as string;
            }
            set
            {
                this[NAME] = value;
            }
        }
    }
}
