using Ejyle.DevAccelerate.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core.Mail
{
    public abstract class MailProviderBase : IMailProvider
    {
        public MailProviderBase()
        {
            var config = DaApplicationContext.GetConfiguration<ProviderConfigurationSection>("mailProviderConfiguration");
            var properties = config.ExtendedProperties;

            SmtpServer = new SmtpServerInfo()
            {
                ApiKey = properties.GetByName("apiKey").Value,
                UserId = properties.GetByName("userId").Value,
                Host = properties.GetByName("host").Value,
                Password = properties.GetByName("password").Value,
                Port = Convert.ToInt32(properties.GetByName("port").Value),
                UseSsl = Convert.ToBoolean(properties.GetByName("useSsl").Value)
            };
            
        }

        protected SmtpServerInfo SmtpServer
        {
            get;
            set;
        }

        public abstract void Send(string to, string from, string subject, string body);
        public abstract void Send(MailMessage message);
        public abstract Task SendAsync(string to, string from, string subject, string body);
        public abstract Task SendAsync(MailMessage message);
    }
}
