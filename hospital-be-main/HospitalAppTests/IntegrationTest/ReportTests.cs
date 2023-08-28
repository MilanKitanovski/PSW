using AutoMapper;
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
using Microsoft.Extensions.FileSystemGlobbing.Internal;
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
    public class ReportTests : BaseIntegrationTest
    {
        public ReportTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static ReportController SetupController(IServiceScope scope, ControllerContext controllerContext)
        {
            return new ReportController(scope.ServiceProvider.GetRequiredService<IReportService>(),
                scope.ServiceProvider.GetRequiredService<IJwtService>(), scope.ServiceProvider.GetRequiredService<IInternalDataService>(),
                scope.ServiceProvider.GetRequiredService<IAppointmentService>(), scope.ServiceProvider.GetRequiredService<IPatientService>(), scope.ServiceProvider.GetRequiredService<IDoctorService>())
            {
                ControllerContext = controllerContext
            };
        }

        private static ReportController ContorlerSetup(IServiceScope scope)
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
        public void Get_All_Reports_From_User()
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
            var result = ((OkObjectResult)controller.GetAllReportsFromUser())?.Value as List<ReportForPatientView>;
            result.ShouldNotBeEmpty();
        }

        [Fact]
        public void Create_report()
        {
            using var scope = Factory.Services.CreateScope();
            ReportController controller = ContorlerSetup(scope);

            var reportDTO = new ReportDTO
            {
                PatientId = new Guid("21e0b73f-df84-4fcb-93c1-029395181800"),
                Diagnosis = "JAOOO",
                Treatment = "Nema spasa",
                AppointmentId = new Guid("ffafa2e4-ee6b-4cd4-95f7-7704339ece0f"),
                InternalData = new InternalDataDTO { 
                    BloodPressure = "21343",
                    BloodSugar = 3.0,
                    Fats = 5.2,
                    Weight = 12.5,
                    Menstrual = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(1),
                                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0).AddDays(3))
                }
            };

            var result = ((OkObjectResult)controller.CreateReport(reportDTO))?.Value;
            result.ToString().ShouldBe("{ message = Report created }");
        }

        [Fact]
        public void Create_report_without_internal_data()
        {
            using var scope = Factory.Services.CreateScope();
            ReportController controller = ContorlerSetup(scope);

            var reportDTO = new ReportDTO
            {
                PatientId = new Guid("21e0b73f-df84-4fcb-93c1-029395181800"),
                Diagnosis = "JAOOO",
                Treatment = "Nema spasa",
                AppointmentId = new Guid("ffafa2e4-ee6b-4cd4-95f7-7704339ece0f"),
                InternalData = new InternalDataDTO
                {
                    BloodPressure = "21343",
                    BloodSugar = 3.0,
                    Fats = 5.2,
                    Weight = 12.5,
                }
            };

            var result = ((OkObjectResult)controller.CreateReport(reportDTO))?.Value;
            result.ToString().ShouldBe("{ message = Report created }");
        }

        [Fact]
        public void Create_report_without_diagnosis()
        {
            using var scope = Factory.Services.CreateScope();
            ReportController controller = ContorlerSetup(scope);

            var reportDTO = new ReportDTO
            {
                PatientId = new Guid("21e0b73f-df84-4fcb-93c1-029395181800"),
                Treatment = "Nema spasa",
                AppointmentId = new Guid("ffafa2e4-ee6b-4cd4-95f7-7704339ece0f"),
                InternalData = new InternalDataDTO
                {
                    BloodPressure = "21343",
                    BloodSugar = 3.0,
                    Fats = 5.2,
                    Weight = 12.5,
                    Menstrual = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(1),
                                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0).AddDays(3))
                }
            };

            var result = ((BadRequestObjectResult)controller.CreateReport(reportDTO))?.Value;
            result.ToString().ShouldBe("{ message = Diagnosis is emtpy }");
        }

        [Fact]
        public void Create_report_without_treatment()
        {
            using var scope = Factory.Services.CreateScope();
            ReportController controller = ContorlerSetup(scope);

            var reportDTO = new ReportDTO
            {
                PatientId = new Guid("21e0b73f-df84-4fcb-93c1-029395181800"),
                Diagnosis = "JAOOO",
                AppointmentId = new Guid("ffafa2e4-ee6b-4cd4-95f7-7704339ece0f"),
                InternalData = new InternalDataDTO
                {
                    BloodPressure = "21343",
                    BloodSugar = 3.0,
                    Fats = 5.2,
                    Weight = 12.5,
                    Menstrual = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(1),
                                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0).AddDays(3))
                }
            };

            var result = ((BadRequestObjectResult)controller.CreateReport(reportDTO))?.Value;
            result.ToString().ShouldBe("{ message = Treatment is emtpy }");
        }
    }
}
