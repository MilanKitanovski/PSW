using AutoMapper;
using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IJwtService _jwtService;
        private readonly IInternalDataService _internalDataService;
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public ReportController(IReportService reportService, IJwtService jwtService, IInternalDataService internalDataService, IAppointmentService appointmentService, IPatientService patientService, IDoctorService doctorService)
        {
            _reportService = reportService;
            _jwtService = jwtService;
            _internalDataService = internalDataService;
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        [HttpPost("createReport")]
        //[Authorize(Roles = "Doctor")]
        public ActionResult createReport([FromBody] ReportDTO dto)
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);
                Patient patient = _patientService.GetById(dto.PatientId);
                Doctor doctor = _doctorService.GetById(dto.DoctorId);
                Appointment appointment = _appointmentService.GetById(dto.AppointmentId);
                var internalData = new InternalData(Guid.NewGuid(), patient, dto.InternalData.BloodPressure, dto.InternalData.BloodSugar, dto.InternalData.Fats, dto.InternalData.Weight, dto.InternalData.Menstrual);
                _internalDataService.Create(internalData);

                var report = new Report(Guid.NewGuid(), doctor, dto.Diagnosis, dto.Treatment, internalData, patient, appointment);
                _reportService.Create(report);
                _appointmentService.FinishAppointment(dto.AppointmentId);

                return Ok(new { message = "Report created" });
            }catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("allReports")]
        [Authorize(Roles = "Patient")]
        public ActionResult GetAllReportsFromUser(Guid id)
        {
            try
            {
                //TODO id trenutnog user-a
                var reports = _reportService.GetAllReportsFromUser(id);
                return Ok(reports);
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
          

        }
    }
}
