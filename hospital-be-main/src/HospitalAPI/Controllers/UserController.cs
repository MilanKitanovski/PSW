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
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPatientService _petientService;
        private readonly IUserService _userService;
        private readonly IDoctorService _doctorService;
        public UserController( IConfiguration configuration, IPatientService petientService, IUserService userService, IDoctorService doctorService)
        {
            _configuration = configuration;
            _petientService = petientService;
            _userService = userService;
            _doctorService = doctorService;
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public ActionResult Register([FromBody] RegisterDTO dto)
        {
            try
            {
                User user = new User(Guid.NewGuid(), Guid.NewGuid(), UserType.Patient, dto.Email, dto.Password);
                _userService.Create(user);

                Patient patient = new Patient(user.PersonId, dto.Name, dto.Surname, dto.PhoneNumber, dto.Gender);
                _petientService.RegisterPatient(patient, dto.DoctorId);

                return Ok(new { message = "User registered" });
            }
            
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
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
                return NotFound("Bad credentials");
            }
            catch (BadPasswordException)
            {
                return Unauthorized("Bad credentials");
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
                return Unauthorized("Bad credentials");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }


       

        [HttpPut("blockUser")]
        public ActionResult BlockUser(Guid id)
        {
            try
            {
                //TODO Provera ako je otkazao 3 pregleda i obavestenje na mail-u
                User user = _userService.GetById(id);
                user.Block();
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        
        }

        [HttpPut("unblockUser")]
        public ActionResult UnlockUser(Guid id)
        {
            try
            {
                //TODO Provera ako je otkazao 3 pregleda i obavestenje na mail-u
                User user = _userService.GetById(id);
                user.Unblock();
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }

       

    }
}