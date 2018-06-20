using Ejyle.DevAccelerate.Core.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Ejyle.DevAccelerate.Providers.Sms.Twilio
{
    public class TwilioSmsProvider : SmsProviderBase
    {
        public override void Send(string to, string body)
        {
            TwilioClient.Init(SmsProviderInfo.Sid, SmsProviderInfo.Token);

            var destination = new PhoneNumber(to);
            MessageResource.Create(to, from: new PhoneNumber(SmsProviderInfo.From), body: body);
        }

        public override async Task SendAsync(string to, string body)
        {
            TwilioClient.Init(SmsProviderInfo.Sid, SmsProviderInfo.Token);

            var destination = new PhoneNumber(to);
            await MessageResource.CreateAsync(to, from: new PhoneNumber(SmsProviderInfo.From), body: body);
        }
    }
}
