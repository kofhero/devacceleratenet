// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
namespace Ejyle.DevAccelerate.Subscriptions
{
    public class SubscriptionPlan<TKey, TOptionalKey, TBillingCycle, TSubscription> : EntityBase<TKey>, ISubscriptionPlan<TKey>
        where TBillingCycle : IBillingCycle<TKey>
        where TSubscription : ISubscription<TKey, TOptionalKey>
    {
        public SubscriptionPlan()
        {
            BillingCycles = new HashSet<TBillingCycle>();
            Subscriptions = new HashSet<TSubscription>();
        }

        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? MaximumUsers { get; set; }
        public virtual ICollection<TBillingCycle> BillingCycles { get; set; }
        public virtual ICollection<TSubscription> Subscriptions { get; set; }
    }
}
