using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAppTests.Setup;
using HospitalLibrary.Core.Enum;
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
    public class DoctorTests : BaseIntegrationTest
    {
        public DoctorTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static DoctorController SetupController(IServiceScope scope, ControllerContext controllerContext)
        {
            return new DoctorController(scope.ServiceProvider.GetRequiredService<IDoctorService>())
            {
                ControllerContext = controllerContext
            };
        }

        private static DoctorController ContorlerSetup(IServiceScope scope)
        {
            var identity = new GenericIdentity("Patient", "Federation");
            var contextUser = new ClaimsPrincipal(identity);
            identity.AddClaim(new Claim(type: "userId", value: "3b4fbc0c-3c7f-4e1a-a1bc-25b961584947"));
            identity.AddClaim(new Claim(type: "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", value: "patient1@gmail.com"));
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
        public void Get_all_doctor_opste_prakse()
        {
            using var scope = Factory.Services.CreateScope();
            DoctorController controller = ContorlerSetup(scope);

            var result = ((OkObjectResult)controller.GetAllDoctor_Opste_Prakse())?.Value as List<Doctor>;
            result.ShouldNotBeNull();
        }
        
        [Fact]
        public void Get_doctors_by_specijalization()
        {
            using var scope = Factory.Services.CreateScope();
            DoctorController controller = ContorlerSetup(scope);

            var result = ((OkObjectResult)controller.GetDoctorsBySpecijalization(Specialization.Kardiolog))?.Value as List<Doctor>;
            result.ShouldNotBeNull();
        }
    }
}
