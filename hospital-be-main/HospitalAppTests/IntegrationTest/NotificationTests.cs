using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Model;
using HospitalAppTests.Setup;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppTests.IntegrationTest
{
    public class NotificationTests : BaseIntegrationTest
    {
        public NotificationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static NotificationController SetupController(IServiceScope scope, ControllerContext controllerContext)
        {
            return new NotificationController(scope.ServiceProvider.GetRequiredService<INotificationService>(), scope.ServiceProvider.GetRequiredService<IAdminService>(), scope.ServiceProvider.GetRequiredService<IJwtService>())
            {
                ControllerContext = controllerContext
            };
        }


        private static NotificationController ContorlerSetup(IServiceScope scope)
        {
            var identity = new GenericIdentity("Admin", "Federation");
            var contextUser = new ClaimsPrincipal(identity);
            identity.AddClaim(new Claim(type: "userId", value: "7c8767d2-2241-473e-820b-ac1abd384b69"));
            identity.AddClaim(new Claim(type: "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", value: "admin@gmail.com"));
            var httpContext = new DefaultHttpContext()
            {
                User = contextUser
            };
            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };

            var controller = SetupController(scope, controllerContext);
            return controller;
        }

        [Fact]
        public void Create_notification()
        {
            using var scope = Factory.Services.CreateScope();
            NotificationController controller = ContorlerSetup(scope);

            var notificationDTO = new NotificationDTO
            {
                TextNotification = "213123122131212"
            };

            var result = ((OkObjectResult)controller.CreateNotification(notificationDTO))?.Value;
            result.ToString().ShouldBe("{ message = Notification created }");
        }

        [Fact]
        public void Create_notification_without_text_notifitaction()
        {
            using var scope = Factory.Services.CreateScope();
            NotificationController controller = ContorlerSetup(scope);

            var notificationDTO = new NotificationDTO
            {
            };

            var result = ((BadRequestObjectResult)controller.CreateNotification(notificationDTO))?.Value;
            result.ToString().ShouldBe("{ message = Text of the notification is empty }");
        }

        
        [Fact]
        public void Get_all_notifications()
        {
            using var scope = Factory.Services.CreateScope();
            NotificationController controller = ContorlerSetup(scope);

            var result = ((OkObjectResult)controller.GetAllNotifications())?.Value as List<Notification>;
            result.ShouldNotBeEmpty();
        }

    }
}
