// ----------------------------------------------------------------------------------------------------------------------
// Copyright � Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Notifications.Messages;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Notifications.Recipients
{
    public class NotificationRecipient<TKey, TUserIdKey, TNotificationMessage> : INotificationRecipient<TKey, TUserIdKey>
        where TNotificationMessage : INotificationMessage<TKey>
    {
        public TKey Id { get; set; }

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
