using Ejyle.DevAccelerate.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core.Sms
{
    public abstract class SmsProviderBase : ISmsProvider
    {
        public SmsProviderBase()
        {
            var config = DaApplicationContext.GetConfiguration<SmsConfigurationSection>("daSmsConfiguration");
            var provider = config.Providers.GetByName(config.DefaultProvider);

            SmsProviderInfo = new SmsProviderInfo()
            {
                From = provider.From,
                Sid = provider.Sid,
                Token = provider.Token
            };           
        }

        protected SmsProviderInfo SmsProviderInfo
        {
            get;
            set;
        }

        public abstract void Send(string to, string body);
        public abstract Task SendAsync(string to, string body);
    }
}
