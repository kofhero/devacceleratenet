// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Notifications.Templates
{
    public interface INotificationTemplate<TKey, TNullableKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        TNullableKey SenderId { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
        NotificationMessageFormat MessageFormat { get; set; }
        NotificationPriority Priority { get; set; }
        bool IsMessageParameterized { get; set; }
        bool IsSubjectParameterized { get; set; }
        bool IsActive { get; set; }
    }
}
