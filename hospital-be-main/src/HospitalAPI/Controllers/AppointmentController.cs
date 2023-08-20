using AutoMapper;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public ActionResult GetAllAppointments()
        {
            return Ok(_appointmentService.GetAll());
        }

        [HttpGet("getAllPending/{id}")]
        public ActionResult GetAllPendingAppointment(Guid id)
        {
            return Ok(_appointmentService.GetPandingAppointmentsByPatient(id));
        }

        [HttpGet("getAllFinished/{id}")]
        public ActionResult GetAllFinishedAppointment(Guid id)
        {
            return Ok(_appointmentService.GetFinishedAppointmentsByPatient(id));
        }

        [HttpGet("getAllCanceled/{id}")]
        public ActionResult GetAllCanceledAppointment(Guid id)
        {
            return Ok(_appointmentService.GetCanceledAppointmentsByPatient(id));
        }

        [HttpPost("searchDoctorPriority")]
        public ActionResult SearchForPatientDoctor([FromBody] AppointmentDTO dto)
        {
            return Ok(_appointmentService.SearchForPatientDoctor(dto));
        }

        [HttpPost("searchTimePriority")]
        public ActionResult SearchAppointmentByTimePriority([FromBody] AppointmentDTO dto)
        {
            return Ok(_appointmentService.SearchAppointmentByTimePriority(dto));
        }

        [HttpPut]
        public ActionResult CancleAppointment(Guid appointmentId)
        {
            if (_appointmentService.CanceledAppointment(appointmentId))
            {
                return Ok(new {message = "Appointment success cancled"});
            }
            return BadRequest(new {message = "Cancellation is not possible"});
        }

        [HttpPost]
        public ActionResult ScheduleAppointment([FromBody] ScheduleAppointmentDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var appointment = _mapper.Map<Appointment>(dto);
            _appointmentService.Create(appointment);
            return Ok(new { message = "Appointment success created" });
        }
    }
}
