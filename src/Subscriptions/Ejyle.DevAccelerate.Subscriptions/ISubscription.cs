// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Subscriptions
{
    public interface ISubscription<TKey, TNullableKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        bool IsActive { get; set; }
        decimal BillingAmount { get; set; }
        TKey SubscriptionPlanId { get; set; }
        bool IsTrial { get; set; }
        BillingCycleType? BillingCycleType { get; set; }
        int? BillingCycleStartDay { get; set; }
        int? BillingCycleEndDay { get; set; }
        TKey TenantId { get; set; }
        TKey OwnerUserId { get; set; }
        TNullableKey PaymentMethodId { get; set; }
        DateTime? ExpiryDateUtc { get; set; }
        DateTime CreatedDateUtc { get; set; }
    }
}
