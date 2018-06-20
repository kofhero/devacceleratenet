// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core.Configuration;
using System;
using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Mail
{
    public class MailProviderConfigurationElement : ProviderConfigurationElement
    {
        private const string HOST_NAME = "hostName";
        private const string USER_ID = "userId";
        private const string PASSWORD = "password";
        private const string PORT = "port";
        private const string API_KEY = "apiKey";
        private const string USE_SSL = "useSsl";

        [ConfigurationProperty(HOST_NAME, IsRequired = false, DefaultValue = null)]
        public string HostName
        {
            get
            {
                return this[HOST_NAME] as string;
            }
            set
            {
                this[HOST_NAME] = value;
            }
        }

        [ConfigurationProperty(USER_ID, IsRequired = false, DefaultValue = null)]
        public string UserId
        {
            get
            {
                return this[USER_ID] as string;
            }
            set
            {
                this[USER_ID] = value;
            }
        }

        [ConfigurationProperty(PASSWORD, IsRequired = false, DefaultValue = null)]
        public string Password
        {
            get
            {
                return this[PASSWORD] as string;
            }
            set
            {
                this[PASSWORD] = value;
            }
        }

        [ConfigurationProperty(PORT, IsRequired = false, DefaultValue = 25)]
        public int Port
        {
            get
            {
                return Convert.ToInt32(this[PORT]);
            }
            set
            {
                this[PORT] = value;
            }
        }

        [ConfigurationProperty(API_KEY, IsRequired = false, DefaultValue = null)]
        public string ApiKey
        {
            get
            {
                return this[API_KEY] as string;
            }
            set
            {
                this[API_KEY] = value;
            }
        }

        [ConfigurationProperty(USE_SSL, IsRequired = false, DefaultValue = true)]
        public bool UseSsl
        {
            get
            {
                return Convert.ToBoolean(this[USE_SSL]);
            }
            set
            {
                this[USE_SSL] = value;
            }
        }
    }
}
