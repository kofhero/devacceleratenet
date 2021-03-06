﻿// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Notifications.Senders
{
    public interface INotificationSender<TKey, TUserIdKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TUserIdKey UserId { get; set; }
        string Name { get; set; }
        string EmailAddress { get; set; }
    }
}
