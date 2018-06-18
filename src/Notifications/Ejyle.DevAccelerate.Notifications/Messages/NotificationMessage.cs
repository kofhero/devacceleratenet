// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Notifications.Recipients;
using Ejyle.DevAccelerate.Notifications.Subjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Notifications.Messages
{
    public class NotificationMessage<TKey, TUserIdKey, TNotificationMessageParam, TNotificationRecipient, TNotificationSubjectParam> : INotificationMessage<TKey>
        where TNotificationMessageParam : INotificationMessageParam<TKey>
        where TNotificationRecipient : INotificationRecipient<TKey, TUserIdKey>
        where TNotificationSubjectParam : INotificationSubjectParam<TKey>
    {
        public NotificationMessage()
        {
            MessageParams = new HashSet<TNotificationMessageParam>();
            Recipients = new HashSet<TNotificationRecipient>();
            SubjectParams = new HashSet<TNotificationSubjectParam>();
        }

        public TKey Id { get; set; }

        public TKey NotificationTemplateId { get; set; }

        [StringLength(255)]
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsHtml { get; set; }

        [StringLength(100)]
        public string SenderName { get; set; }

        [StringLength(255)]
        public string SenderEmail { get; set; }
        public NotificationStatus Status { get; set; }
        public NotificationPriority Priority { get; set; }
        public bool HasMessageParams { get; set; }
        public bool HasSubjectParams { get; set; }
        public bool HasRecipientMessageParams { get; set; }
        public bool HasRecipientSubjectParams { get; set; }
        public DateTime? DueData { get; set; }
        public DateTime? SentDate { get; set; }
        public virtual ICollection<TNotificationMessageParam> MessageParams { get; set; }
        public virtual ICollection<TNotificationRecipient> Recipients { get; set; }
        public virtual ICollection<TNotificationSubjectParam> SubjectParams { get; set; }
    }
}
