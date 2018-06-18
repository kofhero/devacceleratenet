// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Notifications.Messages;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Notifications.Subjects
{
    public class NotificationSubjectParam
        : NotificationSubjectParam<int, NotificationMessage>
    { }

    public class NotificationSubjectParam<TKey, TNotificationMessage>
        : EntityBase<TKey>, INotificationSubjectParam<TKey>
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
