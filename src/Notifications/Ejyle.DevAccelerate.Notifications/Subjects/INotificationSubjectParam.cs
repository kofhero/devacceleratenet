// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Notifications.Subjects
{
    public interface INotificationSubjectParam<TKey> : IEntity<TKey>
    {
        string Name { get; set; }
        string Value { get; set; }
        TKey NotificationMessageId { get; set; }
    }
}
