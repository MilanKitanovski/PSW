using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAppTests.Setup;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
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
    public class AppointmentTests : BaseIntegrationTest
    {
        public AppointmentTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static AppointmentController SetupController(IServiceScope scope, ControllerContext controllerContext)
        {

            return new AppointmentController(scope.ServiceProvider.GetRequiredService<IDoctorService>(), scope.ServiceProvider.GetRequiredService<IAppointmentService>(),
                scope.ServiceProvider.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<IJwtService>(), scope.ServiceProvider.GetRequiredService<IPatientService>())
            {
                ControllerContext = controllerContext
            };
        }

        private static AppointmentController ContorlerSetup(IServiceScope scope)
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
        public void Search_For_Patient_Doctor()
        {
            using var scope = Factory.Services.CreateScope();

            AppointmentController controller = ContorlerSetup(scope);

            var searchAppointmentDTO = new SearchAppointmentDTO
            {
                DoctorId = new Guid("e5213e5b-66d3-4f34-8e5c-2087c19f61ab"),
                Range = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(3),
                 new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0).AddDays(3))
            };

            var result = ((OkObjectResult)controller.SearchForPatientDoctor(searchAppointmentDTO))?.Value as List<SearchAppointmentResultDTO>;
            result.ShouldNotBeNull();
        }


        [Fact]
        public void Schedule_Appointment()
        {
            using var scope = Factory.Services.CreateScope();

            AppointmentController controller = ContorlerSetup(scope);

            var scheduleAppointmentDTO = new ScheduleAppointmentDTO
            {
                DoctorId = new Guid("e5213e5b-66d3-4f34-8e5c-2087c19f61ab"),
                Range = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(3),
                 new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0).AddDays(3))
            };

            var result = ((OkObjectResult)controller.ScheduleAppointment(scheduleAppointmentDTO))?.Value;
            result.ToString().ShouldBe("{ message = Appointment success created }");
        }

        [Fact]
        public void Cancle_Appointment()
        {
            using var scope = Factory.Services.CreateScope();

            AppointmentController controller = ContorlerSetup(scope);

            var result = ((OkObjectResult)controller.CancleAppointment(new Guid("13b96e80-c1e2-4675-9a04-bb3d6e4a2610")))?.Value;
            result.ToString().ShouldBe("{ message = Appointment success cancled }");
        }

        [Fact]
        public void Cancle_Appointment_False()
        {
            using var scope = Factory.Services.CreateScope();

            AppointmentController controller = ContorlerSetup(scope);

            var result = ((BadRequestObjectResult)controller.CancleAppointment(new Guid("ffafa2e4-ee6b-4cd4-95f7-7704339ece0f")))?.Value;
            result.ToString().ShouldBe("{ message = Cancellation is not possible }");
        }

        [Fact]
        public void Search_By_Doctors_Direction()
        {
            using var scope = Factory.Services.CreateScope();

            AppointmentController controller = ContorlerSetup(scope);

            var specializationSearchAppointmentDTO = new SpecializationSearchAppointmentDTO
            {
                Priority = Priority.DoctorPriority,
                Specialization = Specialization.Kardiolog,
                DoctorId = new Guid("60427775-a4e7-43a6-9f54-afce9688adcf"),
                Range = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(3),
                     new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0).AddDays(3))
            };
            var result = ((OkObjectResult)controller.SearchByDoctorsDirection(specializationSearchAppointmentDTO))?.Value as List<SearchAppointmentResultDTO>;
            result.ShouldNotBeNull();
        }


        [Fact]
        public void Get_All_Appointments_By_Doctor()
        {
            using var scope = Factory.Services.CreateScope();

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

            var result = ((OkObjectResult)controller.GetAllAppointmentsByDoctor())?.Value as List<ViewAppointmentByDoctorDTO>;
            result.ShouldNotBeNull();
        }
    }
}
