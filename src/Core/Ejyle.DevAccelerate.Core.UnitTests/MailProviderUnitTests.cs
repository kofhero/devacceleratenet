using System;
using System.Net.Mail;
using Ejyle.DevAccelerate.Core.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ejyle.DevAccelerate.Core.UnitTests
{
    [TestClass]
    public class MailProviderUnitTests
    {
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
