// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Represents the default implementation of configuration source which is either web.config or app.config of the application.
    /// </summary>
    public class DefaultConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// Gets a configuration section of a given name from the configuration source.
        /// </summary>
        /// <typeparam name="T">The type of the configuration section.</typeparam>
        /// <param name="configSectionName">The name of the configuration section.</param>
        /// <returns>Returns a generic instance of the <see cref="DaConfigurationSection"/> type.</returns>
        public T GetConfigurationSection<T>(string configSectionName)
            where T : DaConfigurationSection
        {
            return System.Configuration.ConfigurationManager.GetSection(configSectionName) as T;
        }

        /// <summary>
        /// Saves changes into the configuration source. This method is not implemented.
        /// </summary>
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
