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
    public class BlogTests : BaseIntegrationTest
    {
        public BlogTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static BlogController SetupController(IServiceScope scope, ControllerContext controllerContext)
        {
            return new BlogController(scope.ServiceProvider.GetRequiredService<IBlogService>(),
                scope.ServiceProvider.GetRequiredService<IJwtService>(), scope.ServiceProvider.GetRequiredService<IDoctorService>())
            {
                ControllerContext = controllerContext
            };
        }
        
        private static BlogController ContorlerSetup(IServiceScope scope)
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
        public void Create_blog()
        {
            using var scope = Factory.Services.CreateScope();

            BlogController controller = ContorlerSetup(scope);
 
            var blogDto = new BlogDTO
            {
                TextBlog = "123456",
                Theme = BlogTheme.Medicine
            };

            var result = ((OkObjectResult)controller.CreateBlog(blogDto))?.Value;
            result.ToString().ShouldBe("{ message = Blog created }");
        }

        [Fact]
        public void Create_blog_without_TextBlog()
        {
            using var scope = Factory.Services.CreateScope();

            BlogController controller = ContorlerSetup(scope);

            var blogDto = new BlogDTO
            {
                TextBlog = "",
                Theme = BlogTheme.Medicine
            };

            var result = ((BadRequestObjectResult)controller.CreateBlog(blogDto))?.Value;
            result.ToString().ShouldBe("{ message = Textblog is empty }");

        }



        [Fact]
        public void Get_all_blog()
        {
            using var scope = Factory.Services.CreateScope();
            BlogController controller = ContorlerSetup(scope);

            var result = ((OkObjectResult)controller.GetAllBlogs())?.Value as List<Blog>;
            result.ShouldNotBeEmpty();
        }
    }
}
