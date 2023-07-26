using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly NotificationService _notificationService;

        public NotificationController(IUserService userService, NotificationService notificationService)
        {
            _userService = userService;
            _notificationService = notificationService;
        }

        [HttpPost("createNotification")]
        [AllowAnonymous]
        public ActionResult CreateNotification(NotificationDTO dto)
        {
            Notification notification = new Notification(Guid.NewGuid(), dto.AdminId, dto.TextNotification);
            return Ok(notification);
        }

        [HttpGet("allNotifications")]
        public ActionResult GetAllBlogs()
        {
            return Ok(_notificationService.GetAll());
        }

        [HttpDelete("deleteNotification")]
        public ActionResult DeleteNotification(Guid id)
        {
            var notification = _notificationService.GetById(id);
            if (notification == null)
            {
                return NotFound();
            }

            _notificationService.Delete(notification);
            return NoContent();
        }
    }
}
