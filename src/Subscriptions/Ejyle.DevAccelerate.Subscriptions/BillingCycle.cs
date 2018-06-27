// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Subscriptions
{
    public class BillingCycle<TKey, TSubscriptionPlan> : IBillingCycle<TKey>
        where TKey : IEquatable<TKey>
        where TSubscriptionPlan : ISubscriptionPlan<TKey>
    {
        public BillingCycleType BillingCycleType { get; set; }
        public int BillingCycleDuration { get; set; }
        public decimal Amount { get; set; }
        public TKey CurrencyId { get; set; }
        public TKey Id { get; set; }
        public TKey SubscriptionPlanId { get; set; }
        public virtual TSubscriptionPlan SubscriptionPlan { get; set; }
    }
}
