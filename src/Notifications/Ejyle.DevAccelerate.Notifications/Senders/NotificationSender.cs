// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Notifications.Senders
{
    public class NotificationSender
        : NotificationSender<int, string>
    { }

    public class NotificationSender<TKey, TUserIdKey>
        : EntityBase<TKey>, INotificationSender<TKey, TUserIdKey>
    {
        public TUserIdKey UserId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }
    }
}
