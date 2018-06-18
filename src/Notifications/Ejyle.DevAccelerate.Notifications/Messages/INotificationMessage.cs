// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Notifications.Messages
{
    public interface INotificationMessage<TKey> : IEntity<TKey>
    {
        TKey NotificationTemplateId { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
        bool IsHtml { get; set; }
        string SenderName { get; set; }
        string SenderEmail { get; set; }
        NotificationStatus Status { get; set; }
        NotificationPriority Priority { get; set; }
        bool HasMessageParams { get; set; }
        bool HasSubjectParams { get; set; }
        bool HasRecipientMessageParams { get; set; }
        bool HasRecipientSubjectParams { get; set; }
        DateTime? DueData { get; set; }
        DateTime? SentDate { get; set; }
    }
}
