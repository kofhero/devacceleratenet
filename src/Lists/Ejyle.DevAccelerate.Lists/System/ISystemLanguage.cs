﻿// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.System
{
    public interface ISystemLanguage<TKey> : IList<TKey>
        where TKey : IEquatable<TKey>
    { 
        string DisplayName { get; set; }
    }
}
