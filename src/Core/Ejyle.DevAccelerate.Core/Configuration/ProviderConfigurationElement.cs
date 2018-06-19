// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    public class ProviderConfigurationElement : NamedConfigurationElement
    {
        private const string TYPE = "type";

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
    }
}
