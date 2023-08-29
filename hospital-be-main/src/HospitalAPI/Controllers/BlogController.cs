using HospitalAPI.DTO;
using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IJwtService _jwtService;
        private readonly IDoctorService _doctorService;

        public BlogController(IBlogService blogService, IJwtService jwtService, IDoctorService doctorService)
        {
            _blogService = blogService;
            _jwtService = jwtService;
            _doctorService = doctorService;
        }



        [HttpPost("createBlog")]
        [Authorize(Roles = "Doctor")]
        public ActionResult CreateBlog([FromBody] BlogDTO dto)
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);
                Doctor doctor = _doctorService.GetById(user.PersonId);
                Blog blog = new Blog(Guid.NewGuid(), dto.TextBlog, doctor, dto.Theme);
                _blogService.Create(blog);
                return Ok(new {message = "Blog created"});
            }
            catch (EntityObjectValidationFailedException e)
            {
                return BadRequest(new { message = e.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("allBlogs")]
        public ActionResult GetAllBlogs()
        {
            try
            {
                return Ok(_blogService.GetAll());

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
