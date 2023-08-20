using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
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
        private readonly IUserService _userService;

        public ReportController(IReportService reportService, IUserService userService)
        {
            _reportService = reportService;
            _userService = userService;
        }


        [HttpPost("createReport")]
        [Authorize(Roles = "Doctor")]
        public ActionResult createReport([FromBody] ReportDTO dto)
        {
            //TODO id trenutnog doktora 
            //Report report = new Report(Guid.NewGuid(), dto.DoctorId, dto.Diagnosis, dto.UserId,  dto.Treatment, dto.InternalData);
            return Ok();
        }

        [HttpGet("allReports")]
        [Authorize(Roles = "Patient")]
        public ActionResult GetAllReportsFromUser(Guid id)
        {
            //TODO id trenutnog user-a
            var reports = _reportService.GetAllReportsFromUser(id);
            return Ok(reports);

        }

        [HttpDelete("deleteReport")]
        [Authorize(Roles = "Doctor")]
        public ActionResult DeleteReport(Guid id)
        {
            var report = _reportService.GetById(id);
            if (report == null)
            {
                return NotFound();
            }

            _reportService.Delete(report);
            return NoContent();
        }
    }
}
