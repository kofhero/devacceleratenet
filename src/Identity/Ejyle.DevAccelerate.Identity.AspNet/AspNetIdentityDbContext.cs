﻿// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using Ejyle.DevAccelerate.Identity.AspNet.Tenants;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents the identity database context for the underlying data store.
    /// </summary>
    public class AspNetIdentityDbContext : AspNetIdentityDbContext<int, int?, User, Role, UserLogin, UserRole, UserClaim, Tenant, TenantUser, UserSession, UserAgreement, UserAgreementVersion>
    {
        /// <summary>
        /// Creates an instance of the <see cref="AspNetIdentityDbContext"/> class.
        /// </summary>
        public AspNetIdentityDbContext()
            : base("IdentityConnection")
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="AspNetIdentityDbContext"/> class.
        /// </summary>
        public AspNetIdentityDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        /// <summary>
        /// Create a new instance of the <see cref="AspNetIdentityDbContext"/> class.
        /// </summary>
        /// <returns>Returns an instance of the <see cref="AspNetIdentityDbContext"/> class.</returns>
        public static AspNetIdentityDbContext Create()
        {
            return new AspNetIdentityDbContext();
        }
    }

    /// <summary>
    /// Represents the identity database context for the underlying data store.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys among the entities.</typeparam>
    /// <typeparam name="TUser">The type of the user entity.</typeparam>
    /// <typeparam name="TRole">The type of the role entity.</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login entity.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role entity.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim entity.</typeparam>
    public class AspNetIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion>
        : IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>
        where TKey : IEquatable<TKey>
        where TUser : User<TKey, TNullableKey,  TUserLogin, TUserRole, TUserClaim>
        where TRole: Role<TKey, TUserRole>
        where TUserLogin: UserLogin<TKey>
        where TUserRole: UserRole<TKey>
        where TUserClaim: UserClaim<TKey>
        where TTenant : Tenant<TKey, TNullableKey, TTenantUser>
        where TTenantUser : TenantUser<TKey, TNullableKey, TTenant, TUser>
        where TUserSession : UserSession<TKey>
        where TUserAgreement : UserAgreement<TKey, TUserAgreementVersion>
        where TUserAgreementVersion : UserAgreementVersion<TKey, TUserAgreement>
    {
        private const string SCHEMA_NAME = "Identity";

        public AspNetIdentityDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public virtual DbSet<TUserAgreement> UserAgreements { get; set; }
        public virtual DbSet<TUserAgreementVersion> UserAgreementVersions { get; set; }

        public virtual DbSet<TTenant> Tenants { get; set; }
        public virtual DbSet<TTenantUser> TenantUsers { get; set; }

        public virtual DbSet<TUserSession> UserSessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TUser>().ToTable("Users", SCHEMA_NAME);
            modelBuilder.Entity<TRole>().ToTable("Roles", SCHEMA_NAME);
            modelBuilder.Entity<TUserClaim>().ToTable("UserClaims", SCHEMA_NAME);
            modelBuilder.Entity<TUserLogin>().ToTable("UserLogins", SCHEMA_NAME);
            modelBuilder.Entity<TUserRole>().ToTable("UserRoles", SCHEMA_NAME);

            modelBuilder.Entity<TTenant>().ToTable("Tenants", SCHEMA_NAME);
            modelBuilder.Entity<TTenantUser>().ToTable("TenantUsers", SCHEMA_NAME);
            modelBuilder.Entity<TUserSession>().ToTable("UserSessions", SCHEMA_NAME);

            modelBuilder.Entity<UserAgreement>().ToTable("UserAgreements", SCHEMA_NAME);
            modelBuilder.Entity<UserAgreementVersion>().ToTable("UserAgreementVersions", SCHEMA_NAME);

            modelBuilder.Entity<TTenant>()
                .HasMany(e => e.TenantUsers)
                .WithRequired(e => e.Tenant)
                .HasForeignKey(e => e.TenantId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAgreement>()
                .HasMany(e => e.UserAgreementVersions)
                .WithRequired(e => e.UserAgreement)
                .HasForeignKey(e => e.UserAgreementId)
                .WillCascadeOnDelete(false);
        }
    }
}
