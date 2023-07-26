using HospitalAPI.DTO;
using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;


namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;

        public BlogController(IUserService userService, IBlogService blogService)
        {
            _userService = userService;
            _blogService = blogService;
        }

        [HttpPost("createBlog")]
        [Authorize(Roles = "Doctor")]
        //Stavi da doktor to moze da radi
        public ActionResult CreateBlog([FromBody] BlogDTO dto)
        {
            //uzmi trenutnog doktora
            Blog blog = new Blog(Guid.NewGuid(), dto.TextBlog, dto.DoctorId, dto.Theme); 

            return Ok(blog);
        }

        [HttpGet("allBlogs")]
        public ActionResult GetAllBlogs()
        {
            return Ok(_blogService.GetAll());
        }

        [HttpDelete("deleteBlog")]
        public ActionResult DeleteBlog(Guid id)
        {
            var blog = _blogService.GetById(id);
            if (blog == null)
            {
                return NotFound();
            }

            _blogService.Delete(blog);
            return NoContent();
        }

    }
}
