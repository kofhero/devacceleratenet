// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Senders;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Notifications.Templates
{
    public class NotificationTemplate : NotificationTemplate<int, int?, string, NotificationSender>
    {
    }

    public class NotificationTemplate<TKey, TOptionalKey, TUserIdKey, TNotificationSender>
        : EntityBase<TKey>, INotificationTemplate<TKey, TOptionalKey>
        where TNotificationSender : INotificationSender<TKey, TUserIdKey>
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public NotificationMessageFormat MessageFormat { get; set; }

        public NotificationPriority Priority { get; set; }

        public bool IsMessageParameterized { get; set; }

        public bool IsSubjectParameterized { get; set; }

        public bool IsActive { get; set; }

        public TOptionalKey SenderId { get; set; }

        public virtual TNotificationSender Sender { get; set; }
    }
}