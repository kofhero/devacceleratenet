// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Templates;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Notifications.Senders
{
    public class NotificationSender
        : NotificationSender<int, int?, string, NotificationTemplate>
    {
        public NotificationSender()
            : base()
        { }
    }

    public class NotificationSender<TKey, TOptionalKey, TUserIdKey, TNotificationTemplate>
        : EntityBase<TKey>, INotificationSender<TKey, TUserIdKey>
        where TNotificationTemplate: INotificationTemplate<TKey, TOptionalKey>
    {
        public NotificationSender()
        {
            Templates = new HashSet<TNotificationTemplate>();
        }

        public TUserIdKey UserId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }

        public virtual ICollection<TNotificationTemplate> Templates { get; set; }
    }
}
