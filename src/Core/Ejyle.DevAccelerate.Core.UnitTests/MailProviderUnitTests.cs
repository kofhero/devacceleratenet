// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Net.Mail;
using Ejyle.DevAccelerate.Core.Configuration;
using Ejyle.DevAccelerate.Core.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ejyle.DevAccelerate.Core.UnitTests
{
    [TestClass]
    public class MailProviderUnitTests
    {
        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            MailConfigurationManager.SetConfiguration(new DefaultConfigurationSource());
        }

        [TestMethod]
        public void GetMailProviderTest()
        {
            var mailProvider = MailProviderFactory.GetProvider();
            Assert.IsNotNull(mailProvider, "Mail provider is null.");
        }

        [TestMethod]
        public void SendMailMessage()
        {
            var mailProvider = MailProviderFactory.GetProvider();
            mailProvider.Send(new MailMessage("someone@example.com", "someone@example.com")
            {
                Subject = "Some subject",
                Body = "Some message"
            });
        }
    }
}
