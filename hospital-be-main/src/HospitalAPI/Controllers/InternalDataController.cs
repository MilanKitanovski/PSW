using AutoMapper;
using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class InternalDataController : ControllerBase
    {
      
        private readonly IInternalDataService _internalDataService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;

        public InternalDataController(IInternalDataService internalDataService, IJwtService jwtService, IMapper mapper, IPatientService patientService)
        {
            _internalDataService = internalDataService;
            _jwtService = jwtService;
            _mapper = mapper;
            _patientService = patientService;
        }


        [HttpGet("allDatas")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetAllInternalDatas() 
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);
                List<InternalDataDTO> iDatas = new List<InternalDataDTO>();

                foreach (var id in _internalDataService.GetAllDatasForUser(user.PersonId))
                {
                    iDatas.Add(_mapper.Map<InternalDataDTO>(id));

                }

                return Ok(iDatas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
           
        }

        [HttpPost("patientCreateData")]
        public IActionResult PatientCreateData(InternalDataDTO dto)
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);
                Patient patient = _patientService.GetById(user.PersonId);
                InternalData iData = new InternalData(Guid.NewGuid(), patient, dto.BloodPressure, dto.BloodSugar, dto.Fats, dto.Weight, dto.Menstrual);
                _internalDataService.Create(iData);
                return Ok(new { message = "Internal data created" });

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
