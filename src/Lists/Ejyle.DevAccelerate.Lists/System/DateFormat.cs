// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Lists.System
{
    public class DateFormat : DateFormat<int, int?, GlobalTimeZone>
    { }

    public class DateFormat<TKey, TNullableKey, TGlobalTimeZone> : ListBase<TKey>, IDateFormat<TKey>
        where TKey : IEquatable<TKey>
        where TGlobalTimeZone : IGlobalTimeZone<TKey, TNullableKey>
    {
        public DateFormat()
        {
            this.TimeZones = new HashSet<TGlobalTimeZone>();
        }

        [Required]
        [StringLength(256)]
        public string DateFormatExpression
        {
            get;
            set;
        }

        [Required]
        public DateFormatType DateFormatType
        {
            get;
            set;
        }

        public virtual ICollection<TGlobalTimeZone> TimeZones
        {
            get;
            set;
        }
    }
}
