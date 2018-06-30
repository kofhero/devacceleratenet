// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;

namespace Ejyle.DevAccelerate.Apps
{
    public class AppsDbContext : AppsDbContext<int, App, AppFeature>
    {
        public AppsDbContext()
            : base("AppsConnection")
        { }

        public AppsDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }
    }

    public class AppsDbContext<TKey, TApp, TAppFeature> : DbContext
        where TKey : IEquatable<TKey>
        where TApp : App<TKey, TAppFeature>
        where TAppFeature : AppFeature<TKey, TApp>
    {
        private const string SCHEMA_NAME = "Apps";

        public AppsDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public virtual DbSet<TApp> Apps { get; set; }
        public virtual DbSet<TAppFeature> AppFeature { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TApp>().ToTable("Apps", SCHEMA_NAME);
            modelBuilder.Entity<TAppFeature>().ToTable("AppFeatures", SCHEMA_NAME);

            modelBuilder.Entity<TApp>()
                .HasMany(e => e.AppFeatures)
                .WithRequired(e => e.App)
                .HasForeignKey(e => e.AppId)
                .WillCascadeOnDelete(false);
        }
    }
}
