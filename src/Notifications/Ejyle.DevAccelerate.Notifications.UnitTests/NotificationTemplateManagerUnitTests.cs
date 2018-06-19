using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Notifications.Templates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ejyle.DevAccelerate.Notifications.UnitTests
{
    [TestClass]
    public class NotificationTemplateManagerUnitTests
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public async Task CreateNotificationTemplate()
        {
            var notificationTemplateRepository = new NotificationTemplateRepository(new NotificationsDbContext());
            var notificationsTemplateManager = new NotificationTemplateManager(notificationTemplateRepository);

            var notificationTemplate = new NotificationTemplate()
            {
                 Name = "Password Reset Template",
                 Message = "Test"
            };

           await notificationsTemplateManager.CreateAsync(notificationTemplate);
        }
    }
}
