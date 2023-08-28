using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Model;
using HospitalAppTests.Setup;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
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
    public class DirectionTests : BaseIntegrationTest
    {
        public DirectionTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static DirectionController SetupController(IServiceScope scope, ControllerContext controllerContext)
        {
            return new DirectionController(scope.ServiceProvider.GetRequiredService<IDirectionService>(),
                                            scope.ServiceProvider.GetRequiredService<IJwtService>(),
                                            scope.ServiceProvider.GetRequiredService<IMapper>(),
                                            scope.ServiceProvider.GetRequiredService<IPatientService>())
            {
                ControllerContext = controllerContext
            };
        }

        private static DirectionController ContorlerSetup(IServiceScope scope)
        {
            var identity = new GenericIdentity("Doctor", "Federation");
            var contextUser = new ClaimsPrincipal(identity);
            identity.AddClaim(new Claim(type: "userId", value: "36cc0978-e593-4016-b7d2-208632a451ac"));
            identity.AddClaim(new Claim(type: "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", value: "doctor1@gmail.com"));
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
        public void Get_all_pending_appointment()
        {
            using var scope = Factory.Services.CreateScope();
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
            var result = ((OkObjectResult)controller.GetAllPendingAppointment())?.Value as List<DirectionDTO>;
            Assert.NotNull(result);
        }
        

        [Fact]
        public void Create_direction()
        {
            using var scope = Factory.Services.CreateScope();
            DirectionController controller = ContorlerSetup(scope);

            var directionDTO = new DirectionDTO
            {
                PatientId = new Guid("21e0b73f-df84-4fcb-93c1-029395181800"),
                Specialization = Specialization.Kardiolog
            };

            var result = ((OkObjectResult)controller.CreateDirection(directionDTO))?.Value;


            result.ToString().ShouldBe("{ message = Direction created }");
        }
        

        [Fact]
        public void Create_direction_false()
        {
            using var scope = Factory.Services.CreateScope();
            DirectionController controller = ContorlerSetup(scope);

            var directionDTO = new DirectionDTO
            {
                Specialization = Specialization.Kardiolog
            };

            var result = ((BadRequestObjectResult)controller.CreateDirection(directionDTO))?.Value;


            result.ToString().ShouldBe("{ message = Patient is null }");
        }

    }
}
