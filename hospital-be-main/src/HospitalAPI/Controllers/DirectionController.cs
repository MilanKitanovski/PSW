using AutoMapper;
using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class DirectionController : ControllerBase
    {
        private readonly IDirectionService _directionService;
        private readonly IPatientService _patientService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private IDirectionService directionService;

        public DirectionController(IDirectionService directionService, IJwtService jwtService, IMapper mapper,IPatientService patientService)
        {
            _directionService = directionService;
            _jwtService = jwtService;
            _mapper = mapper;
            _patientService = patientService;
        }



        [HttpGet("getDirectionsByPatient")]
        public ActionResult GetAllPendingAppointment()
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);

                List<DirectionDTO> list = new List<DirectionDTO>();
                foreach (var r in _directionService.GetDirectionsByPatient(user.PersonId))
                {
                    list.Add(_mapper.Map<DirectionDTO>(r));
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPost("CreateDirection")]
        public ActionResult CreateDirection([FromBody]DirectionDTO dto)
        {
            try
            {
       
                var directionDto = _mapper.Map<Direction>(dto);
                Patient patient = _patientService.GetById(directionDto.PatientId);
                Direction direction = new Direction(Guid.NewGuid(),patient,dto.Specialization);
                _directionService.Create(direction);
                return Ok(new { message = "Direction created"});
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



    }
}
