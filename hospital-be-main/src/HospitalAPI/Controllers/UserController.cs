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
using System.Linq;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IPatientService _petientService;
        private readonly IUserService _userService;
        public UserController( IPatientService petientService, IUserService userService)
        {
            _petientService = petientService;
            _userService = userService;
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


       

        [HttpPut("blockUser/{id}")]
        public ActionResult BlockUser(string id)
        {
            try
            {
                _userService.BlockUser(Guid.Parse(id));
                return Ok(new { message = "User is block" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        
        }

        [HttpPut("unblockUser/{id}")]
        public ActionResult UnblockUser(string id)
        {
            try
            {
                _userService.Unblock(Guid.Parse(id));
                return Ok(new { message = "User is unblock" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }

        [HttpGet("allSuspicious")]
        public ActionResult GetAllUserBySuspiciousActivity()
        {
            try
            {
                return Ok(_userService.GetAllUserBySuspiciousActivity().Select(sp => new SuspiciousUserDTO(sp.Id ,sp.Email.Address, sp.IsBlock, sp.NumberOfSuspiciousActivitiesInRecentPeriod())).ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }
        }
    }
}