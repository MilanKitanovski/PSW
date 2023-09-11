using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankNewsController : ControllerBase
    {
        private readonly HospitalDbContext _dbContext; // Inject your DbContext as needed
        private readonly IBloodBankNewsService _bloodBankNewsService;
        private readonly INotificationService _notificationService;
        private readonly IJwtService _jwtService;
        private readonly IAdminService _adminService;
        public BloodBankNewsController(IBloodBankNewsService bloodBankNewsService, INotificationService notificationService, IJwtService jwtService, IAdminService adminService)
        {
            _bloodBankNewsService = bloodBankNewsService;
            _notificationService = notificationService;
            _jwtService = jwtService;
            _adminService = adminService;
        }

        [HttpGet("getAllNews")]
        public ActionResult GetAllNews()
        {
            try
            {
                List<BloodBankNews> news = _bloodBankNewsService.GetPendingAndPublishNews();
                return Ok(news);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("archive/{id}")]
        public ActionResult ArchiveNews(string id)
        {
            try
            {
                _bloodBankNewsService.ArchiveNews(Guid.Parse(id));
                return Ok(new { message = "News is archived" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("publish/{id}")]
        //[Authorize(Roles = "Admin")]

        public ActionResult PublishNews(string id)
        {
            try
            {

             
                User user = _jwtService.GetCurrentUser(HttpContext.User);
                Admin admin = _adminService.GetById(user.PersonId);
                var bloodBankNews = _bloodBankNewsService.GetById(Guid.Parse(id));
                var notification = new Notification(Guid.NewGuid(),admin, bloodBankNews.NewsText);
                _notificationService.Create(notification);

                _bloodBankNewsService.PublishNews(Guid.Parse(id));

                return Ok(new { message = "News is published" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }


        [HttpGet("consume")]
        public async Task<ActionResult> Consume()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "bloodbanknews",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            string mess = "a";
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _bloodBankNewsService.Create(new BloodBankNews(Guid.NewGuid(), message));
                Console.WriteLine($"Received new message: {message}");
                mess = message;
            };

            channel.BasicConsume(queue: "bloodbanknews", autoAck: true, consumer: consumer);

            Console.WriteLine("Consuming");

            await Task.Delay(2000);

            return Ok(mess);
        }
    }
}