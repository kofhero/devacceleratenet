// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Subscriptions
{
    public interface IBillingCycle<TKey> : IEntity<TKey>
    {
        BillingCycleType BillingCycleType { get; set; }
        int BillingCycleDuration { get; set; }
        decimal Amount { get; set; }
        TKey CurrencyId { get; set; }
    }
}
