// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Net.Mail;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Core.Mail
{
    public interface IMailProvider
    {
        void Send(string to, string from, string subject, string body);
        Task SendAsync(string to, string from, string subject, string body);

        void Send(MailMessage message);
        Task SendAsync(MailMessage message);
    }
}
