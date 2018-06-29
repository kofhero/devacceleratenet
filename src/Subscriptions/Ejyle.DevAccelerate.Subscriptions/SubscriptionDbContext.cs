// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;

namespace Ejyle.DevAccelerate.Subscriptions
{
    public class SubscriptionDbContext<TKey, TNullableKey, TSubscriptionPlan, TSubscription, TBillingCycle> : DbContext
        where TKey : IEquatable<TKey>
        where TSubscription : Subscription<TKey, TNullableKey, TSubscriptionPlan>
        where TSubscriptionPlan : SubscriptionPlan<TKey, TNullableKey, TBillingCycle, TSubscription>
        where TBillingCycle : BillingCycle<TKey, TSubscriptionPlan>
    {
        private const string SCHEMA_NAME = "Subscriptions";

        public SubscriptionDbContext()
            : base("SubscriptionsDbConnection")
        { }

        public DbSet<TBillingCycle> BillingCycles { get; set; }
        public DbSet<TSubscriptionPlan> SubscriptionPlan { get; set; }
        public DbSet<TSubscription> Subscription { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {       
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TBillingCycle>().ToTable("BillingCycles", SCHEMA_NAME);
            modelBuilder.Entity<TSubscriptionPlan>().ToTable("SubscriptionPlans", SCHEMA_NAME);
            modelBuilder.Entity<TSubscription>().ToTable("Subscriptions", SCHEMA_NAME);

            modelBuilder.Entity<TSubscriptionPlan>()
                .HasMany(e => e.BillingCycles)
                .WithOptional(e => e.SubscriptionPlan)
                .HasForeignKey(e => e.SubscriptionPlanId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TSubscriptionPlan>()
                .HasMany(e => e.Subscriptions)
                .WithOptional(e => e.SubscriptionPlan)
                .HasForeignKey(e => e.SubscriptionPlanId)
                .WillCascadeOnDelete(false);
        }
    }
}
