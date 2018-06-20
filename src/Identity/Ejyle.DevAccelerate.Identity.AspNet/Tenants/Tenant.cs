// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Identity.AspNet.Tenants
{
    public class Tenant : Tenant<string, TenantUser>
    {
        public Tenant() : base()
        { }
    }

    public class Tenant<TKey, TTenantUser> : EntityBase<TKey>, ITenant<TKey>
        where TTenantUser : ITenantUser<TKey>
    {
        public Tenant()
        {
            TenantUsers = new List<TTenantUser>();
        }

        public TKey OwnerUserId { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public bool IsDomainVerified { get; set; }
        public string FriendlyName { get; set; }
        public virtual ICollection<TTenantUser> TenantUsers { get; set; }
    }
}
