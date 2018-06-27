using System;
using System.Data.Entity;
using Ejyle.DevAccelerate.Apps.Features;

namespace Ejyle.DevAccelerate.Apps
{
    public class AppsDbContext<TKey, TFeature, TApp, TAppFeature> : DbContext
        where TKey : IEquatable<TKey>
        where TFeature : Feature<TKey>
    {
        private const string SCHEMA_NAME = "Apps";

        public AppsDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public virtual DbSet<TFeature> Features { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TFeature>().ToTable("Features", SCHEMA_NAME);
        }
    }
}
