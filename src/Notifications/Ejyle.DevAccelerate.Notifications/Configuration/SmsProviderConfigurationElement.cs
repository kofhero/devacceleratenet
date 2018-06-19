// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;

namespace Ejyle.DevAccelerate.Notifications.Configuration
{
    public class SmsProviderConfigurationElement : ConfigurationElement
    {
        private const string SID = "sid";
        private const string TOKEN = "token";
        private const string DEFAULT_SENDER = "sender";

        [ConfigurationProperty(SID, IsRequired = false, DefaultValue = null)]
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

        [ConfigurationProperty(TOKEN, IsRequired = false, DefaultValue = null)]
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

        [ConfigurationProperty(DEFAULT_SENDER, IsRequired = false, DefaultValue = null)]
        public string DefaultSender
        {
            get
            {
                return this[DEFAULT_SENDER] as string;
            }
            set
            {
                this[DEFAULT_SENDER] = value;
            }
        }
    }
}
