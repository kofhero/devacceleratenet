// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Contains a collections of the <see cref="ExtendedPropertyConfigurationElement"/> objects.
    /// </summary>
    public class ExtendedPropertyConfigurationElementCollection : NamedConfigurationElementCollection<ExtendedPropertyConfigurationElement>
    {
        /// <summary>
        /// creates a new <see cref="ConfigurationElement" />.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="ExtendedPropertyConfigurationElement"/> class.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ExtendedPropertyConfigurationElement();
        }
    }
}
