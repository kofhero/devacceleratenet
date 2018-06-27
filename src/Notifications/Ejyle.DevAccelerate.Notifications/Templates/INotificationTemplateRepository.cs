// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Templates
{
    public interface INotificationTemplateRepository<TKey, TNullableKey, TNotificationTemplate> : IEntityRepository<TKey, TNotificationTemplate>
        where TKey : IEquatable<TKey>
        where TNotificationTemplate : INotificationTemplate<TKey, TNullableKey>
    {
        Task CreateAsync(TNotificationTemplate notificationTemplate);
        Task<List<TNotificationTemplate>> FindAllAsync();
        Task<TNotificationTemplate> FindByIdAsync(TKey id);
        Task DeleteAsync(TNotificationTemplate notificationTemplate);
        Task UpdateAsync(TNotificationTemplate notificationTemplate);
    }
}
