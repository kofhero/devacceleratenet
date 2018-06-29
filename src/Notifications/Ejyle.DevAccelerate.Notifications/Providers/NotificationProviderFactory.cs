// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Notifications.Messages;
using System;

namespace Ejyle.DevAccelerate.Notifications.Providers
{
    public class NotificationProviderFactory<TKey, TMessage, TNotificationProvider>
        where TKey : IEquatable<TKey>
        where TNotificationProvider : INotificationServiceProvider<TKey, TMessage>
        where TMessage : INotificationMessage<TKey>
    {
        public static TNotificationProvider GetNotificationProvider(string name)
        {
            throw new NotImplementedException();
        }
    }
}
