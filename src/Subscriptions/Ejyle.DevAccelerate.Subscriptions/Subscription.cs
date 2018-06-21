// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Subscriptions
{
    public class Subscription<TKey, TOptionalKey, TSubscriptionPlan> : EntityBase<TKey>, ISubscription<TKey, TOptionalKey>
        where TSubscriptionPlan : ISubscriptionPlan<TKey>
    {
        public Subscription()
        {
        }

        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ExpiryDateUtc { get; set; }
        public decimal BillingAmount { get; set; }
        public BillingCycleType? BillingCycleType { get; set; }
        public int? BillingCycleStartDay { get; set; }
        public int? BillingCycleEndDay { get; set; }
        public TKey TenantId { get; set; }
        public TKey OwnerUserId { get; set; }
        public TOptionalKey PaymentMethodId { get; set; }
        public TKey SubscriptionPlanId { get; set; }
        public bool IsTrial { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public virtual TSubscriptionPlan SubscriptionPlan { get; set; }
    }
}
