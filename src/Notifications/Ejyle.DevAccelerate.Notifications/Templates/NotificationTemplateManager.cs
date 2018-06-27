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
    public class NotificationTemplateManager : NotificationTemplateManager<int, int?, NotificationTemplate, NotificationTemplateRepository>
    {
        public NotificationTemplateManager(NotificationTemplateRepository repository)
            : base(repository)
        { }
    }

    public class NotificationTemplateManager<TKey, TNullableKey, TNotificationTemplate, TRepository>
        : EntityManagerBase<TKey, TNotificationTemplate, TRepository>
        where TKey : IEquatable<TKey>
        where TNotificationTemplate : INotificationTemplate<TKey, TNullableKey>
        where TRepository : INotificationTemplateRepository<TKey, TNullableKey, TNotificationTemplate>
    {
        public NotificationTemplateManager(TRepository repository)
            : base(repository)
        { }

        public Task CreateAsync(TNotificationTemplate notificationTemplate)
        {
            if (notificationTemplate == null)
            {
                throw new ArgumentNullException("notificationTemplate");
            }

            return Repository.CreateAsync(notificationTemplate);
        }

        public Task<List<TNotificationTemplate>> FindAllAsync()
        {
            return Repository.FindAllAsync();
        }

        public Task<TNotificationTemplate> FindByIdAsync(TKey id)
        {
            return Repository.FindByIdAsync(id);
        }

        public Task DeleteAsync(TNotificationTemplate notificationTemplate)
        {
            return Repository.DeleteAsync(notificationTemplate);
        }

        public Task UpdateAsync(TNotificationTemplate notificationTemplate)
        {
            return Repository.UpdateAsync(notificationTemplate);
        }
    }
}
