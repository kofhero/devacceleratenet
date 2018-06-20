// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Exceptions
{
    /// <summary>
    /// Represents the configuration section for exception handling.
    /// </summary>
    public class ExceptionHandlingConfigurationSection : DaProviderConfigurationSection
    {
        private const string DEFAULT_EXCEPTION_POLICY = "defaultExceptionPolicy";

        /// <summary>
        /// Gets or sets the name of the default exception policy.
        /// </summary>
        [ConfigurationProperty(DEFAULT_EXCEPTION_POLICY, IsRequired = false, DefaultValue = "Default Exception Policy")]
        public string DefaultExceptionPolicy
        {
            get
            {
                return this[DEFAULT_EXCEPTION_POLICY] as string;
            }
            set
            {
                this[DEFAULT_EXCEPTION_POLICY] = value;
            }
        }

        /// <summary>
        /// Gets the name of the configuration section.
        /// </summary>
        /// <returns>Returns the name of the configuration section as a <see cref="string"/>.</returns> 
        public override string GetConfigurationSectionName()
        {
            return "daExceptionHandlingConfiguration";
        }
    }
}
