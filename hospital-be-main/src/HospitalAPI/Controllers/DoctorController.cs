using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("allDoctorOpstePrakse")]
        public ActionResult GetAllDoctor_Opste_Prakse()
        {
            try
            {
                List<Doctor> doctors = _doctorService.getAllDoctor_Opste_Prakse();
                if (doctors.Count == 0)
                {
                    return NotFound();
                }

                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("allSpecialists/{specialization}")]
        public ActionResult GetDoctorsBySpecijalization(Specialization specialization)
        {
            try
            {
                List<Doctor> doctors = _doctorService.getAllDoctorsBySpetialization(specialization);
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
    }
}
