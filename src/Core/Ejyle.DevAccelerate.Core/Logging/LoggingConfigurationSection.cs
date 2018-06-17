// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Core.Logging
{
    /// <summary>
    /// Represents the configuration section for logging management in the application.
    /// </summary>
    public class LoggingConfigurationSection : ProviderConfigurationSection
    {
        /// <summary>
        /// Returns daLoggingConfiguration as the name of the configuration section.
        /// </summary>
        /// <returns>Returns the name of the confiuration section as a <see cref="string"/>.</returns>
        public override string GetConfigurationSectionName()
        {
            return "daLoggingConfiguration";
        }
    }
}
