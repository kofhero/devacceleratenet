// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Messages
{
    public interface INotificationMessageRepository<TKey, TNotificationMessage> : IEntityRepository<TKey, INotificationMessage<TKey>>
        where TKey : IEquatable<TKey>
        where TNotificationMessage : INotificationMessage<TKey>
    {
        Task<List<TNotificationMessage>> FindByStatusAsync(NotificationStatus status);
        Task<List<TNotificationMessage>> FindAllAsync();
    }
}
