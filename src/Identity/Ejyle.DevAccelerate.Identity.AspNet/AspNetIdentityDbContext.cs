// ----------------------------------------------------------------------------------------------------------------------
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
    public class AspNetIdentityDbContext : AspNetIdentityDbContext<string, User, Role, UserLogin, UserRole, UserClaim, Tenant, TenantUser>
    {
        /// <summary>
        /// Creates an instance of the <see cref="AspNetIdentityDbContext"/> class.
        /// </summary>
        public AspNetIdentityDbContext()
            : base()
        {
        }

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
    public class AspNetIdentityDbContext<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser>
        : IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>
        where TKey : IEquatable<TKey>
        where TUser : User<TKey, TUserLogin, TUserRole, TUserClaim>
        where TRole: Role<TKey, TUserRole>
        where TUserLogin: UserLogin<TKey>
        where TUserRole: UserRole<TKey>
        where TUserClaim: UserClaim<TKey>
        where TTenant : Tenant<TKey, TTenantUser>
        where TTenantUser : TenantUser<TKey, TTenant, TUser>
    {
        /// <summary>
        /// Creates an instance of the <see cref="AspNetIdentityDbContext"/> class.
        /// </summary>
        public AspNetIdentityDbContext()
            : base("IdentityConnection")
        {
        }

        public DbSet<TTenant> Tenants { get; set; }
        public DbSet<TTenantUser> TenantUsers { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="AspNetIdentityDbContext"/> class.
        /// </summary>
        /// <param name="connectionString">The name of the connection string.</param>
        public AspNetIdentityDbContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
