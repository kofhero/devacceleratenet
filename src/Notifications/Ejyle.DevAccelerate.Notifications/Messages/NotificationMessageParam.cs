// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Notifications.Messages
{
    public class NotificationMessageParam
        : NotificationMessageParam<int, string, NotificationMessage>
    { }

    public class NotificationMessageParam<TKey, TUserIdKey, TNotificationMessage>
        : EntityBase<TKey>, INotificationMessageParam<TKey>
        where TNotificationMessage : INotificationMessage<TKey>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Value { get; set; }
        public TKey NotificationMessageId { get; set; }
        public virtual TNotificationMessage Message { get; set; }
    }
}
