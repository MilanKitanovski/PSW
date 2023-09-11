using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAppTests.Setup;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MimeKit;
using Moq;

namespace HospitalAppTests.IntegrationTest
{
    public class BlockUserTests : BaseIntegrationTest
    {
        public BlockUserTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static UserController SetupController(IServiceScope scope, Mock<IEmailService> mockSendEmail)
        {
            return new UserController(scope.ServiceProvider.GetRequiredService<IPatientService>(), scope.ServiceProvider.GetRequiredService<IUserService>(), scope.ServiceProvider.GetRequiredService<IEmailService>());
        }

        [Fact]
        public void Block_unblocked_user()
        {
            // OVAJ TEST PADA JER NISAM SIGURAN KAKO DA GA URADIM

            var mockSender = new Mock<IEmailService>();
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope, mockSender);

            var result = ((Task<ActionResult>)controller.BlockUser("c86d1f40-35b6-4a29-aba0-1661e06a422f"));


            String recipientName = "Client";
            String recipientEmail = "patient5@gmail.com";
            String subject = "You have been blocked";
            String emailText = "You have been blocked ";
            MimeMessage emailMessage = EmailSending.CreateTxtEmail(recipientName, recipientEmail, subject, emailText);

            mockSender.Verify(n => n.SendEmail(emailMessage), Times.Once);
        }

    }
}
