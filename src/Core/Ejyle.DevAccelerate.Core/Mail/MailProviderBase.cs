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
            var config = DaApplicationContext.GetConfiguration<MailConfigurationSection>("daMailConfiguration");

            DefaultFromName = config.DefaultSenderName;
            DefaultFromEmail = config.DefaultSenderEmail;

            var provider = config.Providers.GetByName(config.DefaultProvider);

            SmtpServer = new SmtpServerInfo()
            {
                ApiKey = provider.ApiKey,
                UserId = provider.UserId,
                Host = provider.HostName,
                Password = provider.Password,
                Port = provider.Port,
                UseSsl = provider.UseSsl
            };            
        }

        protected string DefaultFromName
        {
            get;
            set;
        }

        protected string DefaultFromEmail
        {
            get;
            set;
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
