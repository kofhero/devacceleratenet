using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Core.Configuration;

namespace Ejyle.DevAccelerate.Notifications
{
    public static class NotificationConfigurationManager
    {
        private const string EMAIL_NOTIFICATION_PROVIDER_CONFIG = "daEmailNotificationProviderConfiguration";

        public static void SetEmailNotificationProviderConfiguration(IConfigurationSource configurationSource)
        {
            DaApplicationContext.SetupConfiguration<ProviderConfigurationSection>(EMAIL_NOTIFICATION_PROVIDER_CONFIG, configurationSource);
        }

        public static ProviderConfigurationSection GetEmailNotificationProviderConfiguration()
        {
            return DaApplicationContext.GetConfiguration<ProviderConfigurationSection>(EMAIL_NOTIFICATION_PROVIDER_CONFIG);
        }
    }
}
