using System;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Dto is null");
            }
            
            bool emailExist = _userService.isEmailExist(dto.Email);
            if (emailExist)
                return null;
            
            User registeredUser = _userService.Register(dto);
            return Ok(registeredUser);

        }
    }
}