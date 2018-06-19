// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Notifications;

namespace Ejyle.DevAccelerate.Notifications.Templates
{
    public class NotificationTemplateRepository : NotificationsRepositoryBase<NotificationsDbContext>, INotificationTemplateRepository<int, int?, NotificationTemplate>
    {
        public NotificationTemplateRepository(NotificationsDbContext dbContext)
            : base(dbContext)
        { }

        public Task CreateAsync(NotificationTemplate notificationTemplate)
        {
            if (notificationTemplate == null)
            {
                throw new ArgumentNullException("notificationTemplate");
            }

            DbContext.NotificationTemplates.Add(notificationTemplate);
            return DbContext.SaveChangesAsync();
        }

        public Task<List<NotificationTemplate>> FindAllAsync()
        {
            return DbContext.NotificationTemplates.ToListAsync();
        }

        public Task<NotificationTemplate> FindByIdAsync(int id)
        {
            return DbContext.NotificationTemplates.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task DeleteAsync(NotificationTemplate notificationTemplate)
        {
            if (notificationTemplate == null)
            {
                throw new ArgumentNullException("notificationTemplate");
            }

            DbContext.NotificationTemplates.Remove(notificationTemplate);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(NotificationTemplate notificationTemplate)
        {
            if (notificationTemplate == null)
            {
                throw new ArgumentNullException("notificationTemplate");
            }

            DbContext.Entry(notificationTemplate).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }
    }
}
