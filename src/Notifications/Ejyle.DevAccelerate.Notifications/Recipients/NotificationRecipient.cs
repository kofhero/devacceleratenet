// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Messages;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Notifications.Recipients
{
    public class NotificationRecipient
        : NotificationRecipient<int, string, NotificationMessage>
    { }

    public class NotificationRecipient<TKey, TUserIdKey, TNotificationMessage>
        : EntityBase<TKey>, INotificationRecipient<TKey, TUserIdKey>
        where TKey : IEquatable<TKey>
        where TNotificationMessage : INotificationMessage<TKey>
    {
        [StringLength(100)]
        public string Name { get; set; }
        public TUserIdKey UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }
        public NotificationRecipientType RecipientType { get; set; }
        public TKey NotificationMessageId { get; set; }
        public NotificationStatus Status { get; set; }
        public virtual TNotificationMessage Message { get; set; }
    }
}
