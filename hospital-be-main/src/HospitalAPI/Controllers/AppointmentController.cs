using AutoMapper;
using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private IAppointmentService appointmentService;
        private IAppointmentService appointmentService1;

        public AppointmentController(IDoctorService doctorService, IAppointmentService appointmentService, IMapper mapper, IJwtService jwtService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
            _jwtService = jwtService;
            _patientService = patientService;
            _doctorService = doctorService;

        }

        //for doctor
        [HttpGet("getAllAppointmentByDoctor")]
        public ActionResult GetAllAppointmentsByDoctor()
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);

                var result = _appointmentService.GetAllAppointmentsByDoctor(user.PersonId);
                List<ViewAppointmentByDoctorDTO> list = new List<ViewAppointmentByDoctorDTO>();
                foreach (var r in result)
                {
                    list.Add(new ViewAppointmentByDoctorDTO(r));
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("searchForPatientDoctor")]

        public ActionResult SearchForPatientDoctor([FromBody] SearchAppointmentDTO dto)
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);


                return Ok(_appointmentService.SearchForPatientDoctor(dto, user.PersonId));
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }

        }


        [HttpPut("cancleAppointment")]
        public ActionResult CancleAppointment(Guid appointmentId)
        {
            try
            {
                if (_appointmentService.CanceledAppointment(appointmentId))
                {
                    return Ok(new { message = "Appointment success cancled" });
                }
                return BadRequest(new { message = "Cancellation is not possible" });
            }catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPost("scheduleAppointment")]
        public ActionResult ScheduleAppointment([FromBody] ScheduleAppointmentDTO dto)
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);
                Patient patient = _patientService.GetById(user.PersonId);
                Doctor doctor = _doctorService.GetById(dto.DoctorId);

                var appointment = new Appointment(Guid.NewGuid(), doctor, patient, dto.Range, HospitalLibrary.Core.Enum.Status.Pending);
                _appointmentService.Create(appointment);
                return Ok(new { message = "Appointment success created" });
            }
            catch (EntityObjectValidationFailedException e)
            {
                return BadRequest(new { message = "Entity Object Validation Failed"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPost("searchByDoctorsDirection")]
        public ActionResult SearchByDoctorsDirection([FromBody] SpecializationSearchAppointmentDTO dto)
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);

                return Ok(_appointmentService.SearchByDoctorsDirection(dto));
            }
            catch(Exception ex) 
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }



}
