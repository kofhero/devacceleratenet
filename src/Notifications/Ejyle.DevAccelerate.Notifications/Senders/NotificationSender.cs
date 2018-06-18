// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Notifications.Senders
{
    public class NotificationSender<TKey, TUserIdKey>
        : INotificationSender<TKey, TUserIdKey>
    {
        public TKey Id { get; set; }

        public TUserIdKey UserId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }
    }
}
