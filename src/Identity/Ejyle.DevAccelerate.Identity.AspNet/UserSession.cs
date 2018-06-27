// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class UserSession : UserSession<int>
    { }

    public class UserSession<TKey> : EntityBase<TKey>, IUserSession<TKey>
        where TKey : IEquatable<TKey>
    {
        [Required]
        public TKey UserId
        {
            get;
            set;
        }

        [StringLength(128)]
        [Index("IX_UserSessions_SessionKey", IsUnique = true)]
        public string SessionKey
        {
            get;
            set;
        }

        [StringLength(128)]
        public string SystemSessionId
        {
            get;
            set;
        }

        [Required]
        public DateTime CreatedDateUtc
        {
            get;
            set;
        }

        [Required]
        public DateTime ExpiryDateUtc
        {
            get;
            set;
        }

        public DateTime? ExpiredDateUtc
        {
            get;
            set;
        }

        [StringLength(15)]
        public string IpAddress
        {
            get;
            set;
        }

        [StringLength(500)]
        public string DeviceAgent
        {
            get;
            set;
        }
    }
}
