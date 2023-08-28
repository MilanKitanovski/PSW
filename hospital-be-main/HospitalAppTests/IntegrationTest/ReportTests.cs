using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Model;
using HospitalAppTests.Setup;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /*
        [Fact]
        public void Create_report()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.CreateReport())?.Value as Report;
            Assert.NotNull(result);
        } */
    }
}
