// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Subscriptions
{
    public interface ISubscriptionPlan<TKey> : IEntity<TKey>
    {
        string Name { get; set; }
        bool IsActive { get; set; }
        int? MaximumUsers { get; set; }
    }
}
