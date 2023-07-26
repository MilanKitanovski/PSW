using AutoMapper;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IUserService _userService;
        //private readonly IScheduleService _scheduleService;
        private readonly IMapper _mapper;

        public ScheduleController(IUserService userService, /*IScheduleService scheduleService,*/ IMapper mapper)
        {
            _userService = userService;
            //_scheduleService = scheduleService;
            _mapper = mapper;   
        }   

        /*
        [HttpPost]
        public ActionResult Create([FromBody] ScheduleDTO dto)
        {
            var appointment = _mapper.Map<MedicalAppointment>(dto);
            _medicalAppointmentService.Create(appointment);
            return CreatedAtAction("GetById", new { id = appointment.Id }, appointment);
        }
        */
    }
}
