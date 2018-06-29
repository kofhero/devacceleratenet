// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Notifications.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.Providers
{
    public interface INotificationServiceProvider<TKey, TMessage>
        where TKey : IEquatable<TKey>
        where TMessage : INotificationMessage<TKey>
    {
        Task SendAsync(TMessage message);
        Task SendAsync(List<TMessage> message);
    }
}
