using Ejyle.DevAccelerate.Notifications.Messages;
using System;

namespace Ejyle.DevAccelerate.Notifications.Providers
{
    public class NotificationProviderFactory<TKey, TMessage, TNotificationProvider>
        where TNotificationProvider : INotificationServiceProvider<TKey, TMessage>
        where TMessage : INotificationMessage<TKey>
    {
        public static TNotificationProvider GetNotificationProvider(string name)
        {
            throw new NotImplementedException();
        }
    }
}
