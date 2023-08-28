using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Model;
using HospitalAppTests.Setup;
using HospitalLibrary.Core.DTO;
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
    public class InternalDataTests : BaseIntegrationTest
    {
        public InternalDataTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static InternalDataController SetupController(IServiceScope scope, ControllerContext controllerContext)
        {
            return new InternalDataController(scope.ServiceProvider.GetRequiredService<IInternalDataService>(),
                scope.ServiceProvider.GetRequiredService<IJwtService>(),scope.ServiceProvider.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<IPatientService>())
            {
                ControllerContext = controllerContext
            };
        }

        private static InternalDataController ContorlerSetup(IServiceScope scope)
        {
            var identity = new GenericIdentity("Patient", "Federation");
            var contextUser = new ClaimsPrincipal(identity);
            identity.AddClaim(new Claim(type: "userId", value: "30fe9cb2-9518-460d-be48-7cbd5ba614a4"));
            identity.AddClaim(new Claim(type: "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", value: "patient2@gmail.com"));
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
        public void Get_All_Internal_Datas()
        {
            using var scope = Factory.Services.CreateScope();
            InternalDataController controller = ContorlerSetup(scope);

            var result = ((OkObjectResult)controller.GetAllInternalDatas())?.Value as List<InternalDataDTO>;
            result.ShouldNotBeEmpty();
        }

        [Fact]
        public void Patient_Create_Data()
        {
            using var scope = Factory.Services.CreateScope();
            InternalDataController controller = ContorlerSetup(scope);

            var internalDataDTO = new InternalDataDTO
            {
                BloodPressure = "21343",
                BloodSugar = 3.0,
                Fats = 5.2,
                Weight = 12.5,
                Menstrual = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(1),
                            new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0).AddDays(3))
            };
            var result = ((OkObjectResult)controller.PatientCreateData(internalDataDTO))?.Value;
            result.ToString().ShouldBe("{ message = Internal data created }");
     
        }

        [Fact]
        public void Patient_Create_Data_Without_Blood_Pressure()
        {
            using var scope = Factory.Services.CreateScope();
            InternalDataController controller = ContorlerSetup(scope);

            var internalDataDTO = new InternalDataDTO
            {
                BloodPressure = "",
                BloodSugar = 3.0,
                Fats = 5.2,
                Weight = 12.5,
                Menstrual = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(1),
                            new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0).AddDays(3))
            };
            var result = ((BadRequestObjectResult)controller.PatientCreateData(internalDataDTO))?.Value;
            result.ToString().ShouldBe("{ message = Blood pressure is empty }");
        }

      
    }
}
