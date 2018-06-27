// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Notifications.Recipients
{
    public interface INotificationRecipient<TKey, TUserIdKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        TUserIdKey UserId { get; set; }
        string EmailAddress { get; set; }
        NotificationRecipientType RecipientType { get; set; }
        TKey NotificationMessageId { get; set; }
        NotificationStatus Status { get; set; }
    }
}
