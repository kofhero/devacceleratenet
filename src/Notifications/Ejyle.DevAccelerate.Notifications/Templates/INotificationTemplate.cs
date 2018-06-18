// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.Templates
{
    public interface INotificationTemplate<TKey> : IEntity<TKey>
    {
        string Name { get; set; }
        TKey NotificationSenderId { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
        bool IsHtml { get; set; }
        NotificationPriority Priority { get; set; }
        string Sender { get; set; }
        bool HasMessageParams { get; set; }
        bool HasSubjectParams { get; set; }
        bool HasRecipientMessageParams { get; set; }
        bool HasRecipientSubjectParams { get; set; }
    }
}
