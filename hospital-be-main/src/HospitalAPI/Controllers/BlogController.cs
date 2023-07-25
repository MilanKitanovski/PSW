using HospitalAPI.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;

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
        //Stavi da doktor to moze da radi
        public ActionResult CreateBlog(Guid doctorId, string blogText)
        {
            //uzmi trenutnog doktora
            Blog blog = new Blog(Guid.NewGuid(), blogText, doctorId); 

            return Ok(blog);
        }

        [HttpGet("allBlogs")]
        public ActionResult GetAllBlogs()
        {
            return Ok(_blogService.GetAll());
        }




    }
}
