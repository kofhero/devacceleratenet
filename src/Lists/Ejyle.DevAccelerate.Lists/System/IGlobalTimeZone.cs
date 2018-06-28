// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.System
{
    public interface IGlobalTimeZone<TKey, TNullableKey> : IList<TKey>
        where TKey : IEquatable<TKey>
    {
        string TimeZoneId { get; set; }
        string DisplayName { get; set; }
        TNullableKey DefaultDateFormatId { get; set; }
    }
}
