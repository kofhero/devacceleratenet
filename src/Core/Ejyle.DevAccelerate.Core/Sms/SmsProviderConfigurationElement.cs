using Ejyle.DevAccelerate.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
