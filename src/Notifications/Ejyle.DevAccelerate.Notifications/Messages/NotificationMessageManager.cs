// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Messages
{
    public class NotificationMessageManager<TKey, TNotificationMessage, TRepository>
        where TKey : IEquatable<TKey>
        where TNotificationMessage : INotificationMessage<TKey>
        where TRepository : INotificationMessageRepository<TKey, TNotificationMessage>
    {
        public NotificationMessageManager(TRepository repository)
        { }

        public Task<List<TNotificationMessage>> FindByStatusAsync(NotificationStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<List<TNotificationMessage>> FindAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
