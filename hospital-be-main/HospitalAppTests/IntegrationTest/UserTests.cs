using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.DTO;
using HospitalAPI.Model;
using HospitalAppTests.Setup;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppTests.IntegrationTest
{
    public class UserTests : BaseIntegrationTest
    {
        public UserTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
    private static UserController SetupController(IServiceScope scope)
    {
            return new UserController(scope.ServiceProvider.GetRequiredService<IPatientService>(), scope.ServiceProvider.GetRequiredService<IUserService>(), scope.ServiceProvider.GetRequiredService<IEmailService>());
       
    }

        [Fact]
        public void Register()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var registerDTO = new RegisterDTO
            {
                Name = "Test",
                Surname = "Test",
                Email = "Random@gmail.com",
                Password = "Test",
                PhoneNumber = "12345",
                DoctorId = new Guid("e5213e5b-66d3-4f34-8e5c-2087c19f61ab"),
                Gender = Gender.Male
            };

            var result = ((OkObjectResult)controller.Register(registerDTO))?.Value;
            result.ToString().ShouldBe("{ message = User registered }");
        }


        [Fact]
        public void Register_with_not_unique_email()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var registerDTO = new RegisterDTO
            {
                Name = "Test",
                Surname = "Test",
                Email = "patient1@gmail.com",
                Password = "Test",
                PhoneNumber = "12345",
                DoctorId = new Guid("e5213e5b-66d3-4f34-8e5c-2087c19f61ab"),
                Gender = Gender.Male
            };

            var result = ((BadRequestObjectResult)controller.Register(registerDTO))?.Value;
            result.ToString().ShouldBe("{ message = Email is not unique }");
        }

        [Fact]
        public void Register_without_doctorId()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var registerDTO = new RegisterDTO
            {
                Name = "Test",
                Surname = "Test",
                Email = "Test@gmail.com",
                Password = "Test",
                PhoneNumber = "12345",
                Gender = Gender.Male
            };

            var result = ((BadRequestObjectResult)controller.Register(registerDTO))?.Value;
            result.ToString().ShouldBe("{ message = Doctor is empty }");
        }

        [Fact]
        private void Login()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var loginDTO = new LoginDTO
            {
                Email = "patient1@gmail.com",
                Password = "123"
            };
            var result = controller.Login(loginDTO);
            result.ShouldBeOfType<OkObjectResult>();
        }

        [Fact]
        private void Login_with_valid_email_and_bad_password()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var loginDTO = new LoginDTO
            {
                Email = "patient1@gmail.com",
                Password = "321"
            };
            var result = ((UnauthorizedObjectResult)controller.Login(loginDTO))?.Value;
            result.ToString().ShouldBe("Bad credentials");

        }

        [Fact]
        private void Login_with_bad_email_and_valid_password()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var loginDTO = new LoginDTO
            {
                Email = "nestp1@gmail.com",
                Password = "123"
            };
            var result = ((NotFoundObjectResult)controller.Login(loginDTO))?.Value;
            result.ToString().ShouldBe("Bad credentials");

        }


        [Fact]
        private void Get_All_User_By_Suspicious_Activity()
        {

            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetAllUserBySuspiciousActivity())?.Value as List<SuspiciousUserDTO>;
            result.Count().ShouldBe(5);
        }


        [Fact]
        private void Unblocked_Block_User()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);


            var result = ((OkObjectResult)controller.UnblockUser("a59197e6-a685-4122-be24-b6a2ae477b9d"))?.Value;
            result.ToString().ShouldBe("{ message = User is unblock }");
        }

        [Fact]
        private void Unblocked_UnBlock_User()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);


            var result = ((BadRequestObjectResult)controller.UnblockUser("4ab3fe26-cdb1-44e8-aadb-70e4cb9ebc40"))?.Value;
            result.ToString().ShouldBe("{ message = User is not blocked }");
        }
    }

}
