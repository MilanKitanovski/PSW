using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Core.Model;
using System.Net;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Enum;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPatientService _petientService;
        private readonly IUserService _userService;
        public UserController( IConfiguration configuration, IPatientService petientService, IUserService userService)
        {
            _configuration = configuration;
            _petientService = petientService;
            _userService = userService;
        }

        /* [HttpPost("register")]
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
         } */

        [HttpPost("register")]
        [AllowAnonymous]
        public ActionResult Register([FromBody] RegisterDTO dto)
        {
            try
            {
             

                Patient patient = new Patient(Guid.NewGuid(), dto.Name, dto.Surname, /*new Email(dto.Email),dto.Password, */dto.PhoneNumber, dto.Gender);
                _petientService.RegisterPatient(patient, dto.DoctorId);

                return Ok();  
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValueObjectValidationFailedException exception)
            {
                return BadRequest("Value object error");
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                var token = _userService.Authenticate(loginDto.Email, loginDto.Password);
                return Ok(new JwtDto(token));
            }
            catch (NotFoundException)
            {
                return NotFound("User not found");
            }
            catch (BadPasswordException)
            {
                return Unauthorized("Bad password");
            }
            catch (AccountNotActivatedException)
            {
                return StatusCode(403);
            }
            catch (UnauthorizedException)
            {
                return Unauthorized("Only patients can login from public app");
            }
            catch (UserIsBlockedException)
            {
                return Unauthorized("Your account has been blocked");
            }
            catch (ValueObjectValidationFailedException)
            {
                return Unauthorized("Bad password");
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }
        }


        [HttpGet("allDoctors")]
        public ActionResult GetAllDoctors()
        {
            return Ok(/*_userService.GetAllDoctors()*/);
        }

        [HttpPut("blockUser")]
        public ActionResult BlockUser(Guid id)
        {
            //TODO Provera ako je otkazao 3 pregleda i obavestenje na mail-u
            User user = _userService.GetById(id);
            user.Block();
            return Ok(user);
        }

        [HttpPut("unblockUser")]
        public ActionResult UnlockUser(Guid id)
        {
            //TODO Provera ako je otkazao 3 pregleda i obavestenje na mail-u
            User user = _userService.GetById(id);
            user.Unblock();
            return Ok(user);
        }

    }
}