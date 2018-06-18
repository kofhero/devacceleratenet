// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Notifications.Templates
{
    public class NotificationTemplate<TKey>
        : EntityBase<TKey>, INotificationTemplate<TKey>
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public TKey NotificationSenderId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsHtml { get; set; }
        public NotificationPriority Priority { get; set; }
        [StringLength(255)]
        public string Sender { get; set; }
        public bool HasMessageParams { get; set; }
        public bool HasSubjectParams { get; set; }
        public bool HasRecipientMessageParams { get; set; }
        public bool HasRecipientSubjectParams { get; set; }
    }
}