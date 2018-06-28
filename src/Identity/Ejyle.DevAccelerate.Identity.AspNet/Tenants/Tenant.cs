// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Identity.AspNet.Tenants
{
    public class Tenant : Tenant<int, TenantUser>
    {
        public Tenant() : base()
        { }
    }

    public class Tenant<TKey, TTenantUser> : Tenant<TKey>
        where TKey : IEquatable<TKey>
        where TTenantUser : ITenantUser<TKey>
    {
        public Tenant()
        {
            TenantUsers = new List<TTenantUser>();
        }

        public virtual ICollection<TTenantUser> TenantUsers { get; set; }
    }

    public class Tenant<TKey> : EntityBase<TKey>, ITenant<TKey>
        where TKey : IEquatable<TKey>
    {
        public TenantType TenantType { get; set; }
        public TKey OwnerUserId { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public bool IsDomainOwnershipVerified { get; set; }
        public string FriendlyName { get; set; }
        public string TenantKey { get; set; }
        public AccountStatus Status { get; set; }
    }
}
