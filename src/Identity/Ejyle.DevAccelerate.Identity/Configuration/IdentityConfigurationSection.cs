// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Identity.Configuration
{
    /// <summary>
    /// Represents the configuration section for identity management in the application.
    /// </summary>
    /// <remarks>The name of the configuration section is daIdentityConfiguration.</remarks>
    public class IdentityConfigurationSection : DaConfigurationSection
    {
        private const string TWO_FACTOR_POLICY = "twoFactorPolicy";
        private const string USER_NAME_POLICY = "userNamePolicy";
        private const string PASSWORD_POLICY = "passwordPolicy";
        private const string USER_LOCKOUT_POLICY = "userLockoutPolicy";

        /// <summary>
        /// Gets or sets the two factory policy settings.
        /// </summary>
        /// <remarks>The name of the configuration property is twoFactorPolicy.</remarks>
        [ConfigurationProperty(TWO_FACTOR_POLICY, IsRequired = false)]
        public IdentityTwoFactorPolicyConfigurationElement TwoFactorPolicy
        {
            get
            {
                return this[TWO_FACTOR_POLICY] as IdentityTwoFactorPolicyConfigurationElement;
            }
            set
            {
                this[TWO_FACTOR_POLICY] = value;
            }
        }

        /// <summary>
        /// Gets or sets the username policy settings.
        /// </summary>
        /// <remarks>The name of the configuration property is userNamePolicy.</remarks>
        [ConfigurationProperty(USER_NAME_POLICY, IsRequired = false)]
        public IdentityUserNamePolicyConfigurationElement UserNamePolicy
        {
            get
            {
                return this[USER_NAME_POLICY] as IdentityUserNamePolicyConfigurationElement;
            }
            set
            {
                this[USER_NAME_POLICY] = value;
            }
        }

        /// <summary>
        /// Gets or sets the password policy settings.
        /// </summary>
        /// <remarks>The name of the configuration property is passwordPolicy.</remarks>
        [ConfigurationProperty(PASSWORD_POLICY, IsRequired = false)]
        public IdentityPasswordPolicyConfigurationElement PasswordPolicy
        {
            get
            {
                return this[PASSWORD_POLICY] as IdentityPasswordPolicyConfigurationElement;
            }
            set
            {
                this[PASSWORD_POLICY] = value;
            }
        }

        /// <summary>
        /// Gets or sets user lockout policy settings.
        /// </summary>
        /// <remarks>The name of the configuration property is userLockoutPolicy.</remarks>
        [ConfigurationProperty(USER_LOCKOUT_POLICY, IsRequired = false)]
        public IdentityLockoutPolicyConfigurationElement UserLockoutPolicy
        {
            get
            {
                return this[USER_LOCKOUT_POLICY] as IdentityLockoutPolicyConfigurationElement;
            }
            set
            {
                this[USER_LOCKOUT_POLICY] = value;
            }
        }

        /// <summary>
        /// Gets the name of the configuration section.
        /// </summary>
        /// <returns>Returns the name of the configuration section as a <see cref="string"/>.</returns>
        public override string GetConfigurationSectionName()
        {
            return "daIdentityConfiguration";
        }
    }
}
