using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IAdminService _adminService;
        private readonly IJwtService _jwtService;

        public NotificationController(INotificationService notificationService, IAdminService adminService, IJwtService jwtService)
        {
            _notificationService = notificationService;
            _adminService = adminService;
            _jwtService = jwtService;

        }


        [HttpPost("createNotification")]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateNotification([FromBody] NotificationDTO dto)
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);
                Admin admin = _adminService.GetById(user.PersonId);
                Notification notification = new Notification(Guid.NewGuid(), admin, dto.TextNotification);
                _notificationService.Create(notification);
                return Ok(new { message = "Notification created" });
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

        [HttpGet("allNotifications")]
        [AllowAnonymous]
        public ActionResult GetAllNotifications()
        {
            try
            {
                return Ok(_notificationService.GetAll());

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
