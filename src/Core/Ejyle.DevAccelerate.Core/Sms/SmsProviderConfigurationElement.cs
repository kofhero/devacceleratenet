﻿// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Configuration;
using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Sms
{
    public class SmsProviderConfigurationElement : ProviderConfigurationElement
    {
        private const string SID = "sid";
        private const string TOKEN = "token";
        private const string FROM = "from";

        [ConfigurationProperty(SID, IsRequired = false)]
        public string Sid
        {
            get
            {
                return this[SID] as string;
            }
            set
            {
                this[SID] = value;
            }
        }

        [ConfigurationProperty(TOKEN, IsRequired = false)]
        public string Token
        {
            get
            {
                return this[TOKEN] as string;
            }
            set
            {
                this[TOKEN] = value;
            }
        }

        [ConfigurationProperty(FROM, IsRequired = true)]
        public string From
        {
            get
            {
                return this[FROM] as string;
            }
            set
            {
                this[FROM] = value;
            }
        }
    }
}
