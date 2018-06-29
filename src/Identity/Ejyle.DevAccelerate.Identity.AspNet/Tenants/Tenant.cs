// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.Identity.AspNet.Tenants
{
    public class Tenant : Tenant<int, int?, TenantUser>
    {
        public Tenant() : base()
        { }
    }

    public class Tenant<TKey, TNullableKey, TTenantUser> : Tenant<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TTenantUser : ITenantUser<TKey>
    {
        public Tenant()
        {
            TenantUsers = new List<TTenantUser>();
        }

        public virtual ICollection<TTenantUser> TenantUsers { get; set; }
    }

    public class Tenant<TKey, TNullableKey> : EntityBase<TKey>, ITenant<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
    {
        [Required]
        public TenantType TenantType { get; set; }

        [Required]
        public TKey OwnerUserId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Domain { get; set; }

        [Required]
        public bool IsDomainOwnershipVerified { get; set; }

        [StringLength(256)]
        public string FriendlyName { get; set; }

        [StringLength(256)]
        [Required]
        [Index("IX_TenantKey", IsUnique = true)]
        public string TenantKey { get; set; }

        [Required]
        public AccountStatus Status { get; set; }

        public TNullableKey CountryId { get; set; }

        public TNullableKey CurrencyId { get; set; }

        public TNullableKey TimeZoneId { get; set; }

        public TNullableKey DateFormatId { get; set; }

        public TNullableKey DateFormatWithDateOnlyId { get; set; }

        public TNullableKey DateFormatWithTimeOnlyId { get; set; }

        public TNullableKey SystemLanguageId { get; set; }

        [Required]
        public TKey CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDateUtc { get; set; }
    }
}
