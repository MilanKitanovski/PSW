using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Model;
using HospitalAppTests.Setup;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppTests.IntegrationTest
{
    public class NotificationTests : BaseIntegrationTest
    {
        public NotificationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static NotificationController SetupController(IServiceScope scope)
        {
            return new NotificationController(scope.ServiceProvider.GetRequiredService<INotificationService>(), scope.ServiceProvider.GetRequiredService<IAdminService>(), scope.ServiceProvider.GetRequiredService<IJwtService>() );
        }
        /*
        [Fact]
        public void Create_notification()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.CreateNotification())?.Value as Notification;
            Assert.NotNull(result);
        }
        */

        /*
        [Fact]
        public void Get_all_notifications()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetAllNotifications())?.Value as Notification;
            Assert.NotNull(result);
        }
        */
    }
}
