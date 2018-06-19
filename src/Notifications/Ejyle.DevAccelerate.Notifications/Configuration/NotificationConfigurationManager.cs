// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Notifications.Configuration
{
    public static class NotificationConfigurationManager
    {
        private const string NOTIFICATION_CONFIG = "daNotificationConfiguration";

        public static void SetConfiguration(IConfigurationSource configurationSource)
        {
            DaApplicationContext.SetupConfiguration<ProviderConfigurationSection>(NOTIFICATION_CONFIG, configurationSource);
        }

        public static NotificationConfigurationSection GetConfiguration()
        {
            return DaApplicationContext.GetConfiguration<NotificationConfigurationSection>(NOTIFICATION_CONFIG);
        }
    }
}
