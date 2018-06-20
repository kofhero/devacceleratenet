using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core.Sms
{
    public interface ISmsProvider
    {
        void Send(string to, string body);
        Task SendAsync(string to, string body);
    }
}
