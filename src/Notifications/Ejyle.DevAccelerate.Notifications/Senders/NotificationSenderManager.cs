// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Senders
{
    public class NotificationSenderManager<TKey, TUserIdKey, TNotificationSender, TRepository>
        where TKey : IEquatable<TKey>
        where TRepository : INotificationSenderRepository<TKey, TUserIdKey, TNotificationSender>
        where TNotificationSender : INotificationSender<TKey, TUserIdKey>
    {
        public NotificationSenderManager(TRepository repository)
        { }
 
        public Task<List<TNotificationSender>> FindAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
