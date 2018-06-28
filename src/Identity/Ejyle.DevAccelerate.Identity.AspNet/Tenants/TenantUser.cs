// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Identity.AspNet.Tenants
{
    public class TenantUser : TenantUser<int, int?, Tenant, User>
    { }

    public class TenantUser<TKey, TNullableKey, TTenant, TUser> : TenantUser<TKey>
        where TKey : IEquatable<TKey>
        where TTenant : ITenant<TKey>
        where TUser : IUser<TKey, TNullableKey>
    {
        public virtual TTenant Tenant { get; set; }
        public virtual TUser User { get; set; }
    }

    public class TenantUser<TKey> : EntityBase<TKey>, ITenantUser<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey TenantId
        {
            get;
            set;
        }

        public TKey UserId
        {
            get;
            set;
        }

        public bool IsActive { get; set; }
    }
}
