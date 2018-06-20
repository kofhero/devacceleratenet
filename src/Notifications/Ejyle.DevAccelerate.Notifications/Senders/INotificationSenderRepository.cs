// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Senders
{
    public interface INotificationSenderRepository<TKey, TUserIdKey, TNotificationSender>
        : IEntityRepository<TKey, TNotificationSender>
        where TNotificationSender : INotificationSender<TKey, TUserIdKey>
    {
        Task<List<TNotificationSender>> FindAllAsync();
    }
}
