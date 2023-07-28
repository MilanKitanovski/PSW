using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class InternalDataController : ControllerBase
    {
      
        private readonly IInternalDataService _internalDataService;
        private readonly IUserService _userService;

        public InternalDataController(IInternalDataService internalDataService, IUserService userService)
        {
            _internalDataService = internalDataService;
            _userService = userService;
        }


        [HttpGet("allDatas")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetAllInternalDatas(Guid userId) 
        {
            //TODO current user
            return Ok(_internalDataService.GetAllDatasForUser(userId));
        }

        [HttpPost("createData")]
        public IActionResult CreateData(InternalDataDTO dto)
        {

            InternalData iData = new InternalData(Guid.NewGuid(), dto.UserId, dto.BloodPressure, dto.BloodSugar, dto.Fats, dto.Weight,dto.Menstrual);


            return Ok(iData);
        }

        [HttpDelete("deleteData")]
        public ActionResult DeleteInternalData(Guid id)
        {
            var iData = _internalDataService.GetById(id);
            if (iData == null)
            {
                return NotFound();
            }

            _internalDataService.Delete(iData);
            return NoContent();
        }




    }
}
