// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using Ejyle.DevAccelerate.Lists.Geography;
using Ejyle.DevAccelerate.Lists.System;

namespace Ejyle.DevAccelerate.Lists
{
    public class ListsDbContext<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion> : DbContext
        where TKey : IEquatable<TKey>
        where TGlobalTimeZone : GlobalTimeZone<TKey, TNullableKey, TDateFormat, TCountry>
        where TDateFormat : DateFormat<TKey, TNullableKey, TGlobalTimeZone>
        where TSystemLanguage : SystemLanguage<TKey, TCountry>
        where TCurrency: Currency<TKey, TCountry>
        where TCountry : Country<TKey, TNullableKey, TCurrency, TGlobalTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : CountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
    {
        private const string SCHEMA_NAME = "lists";

        public ListsDbContext(string nameOfConnectionString)
            : base(nameOfConnectionString)
        { }

        public virtual DbSet<TGlobalTimeZone> GlobalTimeZones { get; set; }
        public virtual DbSet<TSystemLanguage> SystemLanguages { get; set; }
        public virtual DbSet<TCountry> Countries { get; set; }
        public virtual DbSet<TCurrency> Currencies { get; set; }
        public virtual DbSet<TDateFormat> DateFormats { get; set; }
        public virtual DbSet<TCountryRegion> StateRegions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TGlobalTimeZone>().ToTable("GlobalTimeZones", SCHEMA_NAME);
            modelBuilder.Entity<TSystemLanguage>().ToTable("SystemLanguages", SCHEMA_NAME);
            modelBuilder.Entity<TCountry>().ToTable("Countries", SCHEMA_NAME);
            modelBuilder.Entity<TCurrency>().ToTable("Currencies", SCHEMA_NAME);
            modelBuilder.Entity<TDateFormat>().ToTable("DateFormats", SCHEMA_NAME);
            modelBuilder.Entity<TCountryRegion>().ToTable("CountryRegions", SCHEMA_NAME);

            modelBuilder.Entity<TCountry>()
                .HasMany(e => e.GlobalTimeZones)
                .WithMany(e => e.Countries)
                .Map(m => m.ToTable("CountryGlobalTimeZones", SCHEMA_NAME)
                .MapLeftKey("CountryId")
                .MapRightKey("GlobalTimeZoneId"));

            modelBuilder.Entity<TCountry>()
                .HasMany(e => e.SystemLanguages)
                .WithMany(e => e.Countries)
                .Map(m => m.ToTable("CountrySystemLanguages", SCHEMA_NAME)
                .MapLeftKey("CountryId")
                .MapRightKey("SystemLanguageId"));

            modelBuilder.Entity<TCurrency>()
                .HasMany(e => e.Countries)
                .WithRequired(e => e.Currency)
                .HasForeignKey(e => e.CurrencyId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TCountry>()
                .HasMany(e => e.Regions)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TCountryRegion>()
                .HasMany(e => e.Children)
                .WithOptional(e => e.Parent)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<TDateFormat>()
                .HasMany(e => e.TimeZones)
                .WithOptional(e => e.DefaultDateFormat)
                .HasForeignKey(e => e.DefaultDateFormatId)
                .WillCascadeOnDelete(false);
        }
    }
}
