// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;

namespace Ejyle.DevAccelerate.Identity.Configuration
{
    /// <summary>
    /// Represents configuration for two-factor policy.
    /// </summary>
    public class IdentityTwoFactorPolicyConfigurationElement : ConfigurationElement
    {
        private const string IS_ENABLED = "isEnabled";

        /// <summary>
        /// Determines if the two-factor policy is enabled.
        /// </summary>
        /// <remarks>The name of the configuration property is isEnabled and the default value is False.</remarks>
        [ConfigurationProperty(IS_ENABLED, IsRequired = false, DefaultValue = false)]
        public bool IsEnabled
        {
            get
            {
                return Convert.ToBoolean(this[IS_ENABLED]);
            }
            set
            {
                this[IS_ENABLED] = value;
            }
        }
    }
}
