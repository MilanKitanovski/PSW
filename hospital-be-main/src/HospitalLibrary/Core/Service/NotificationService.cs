using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IAdminRepository _adminRepository;

        public NotificationService(INotificationRepository notificationRepository, IAdminRepository adminRepository)
        {
            _notificationRepository = notificationRepository;
            _adminRepository = adminRepository;
        }

        public void Create(Notification notification)
        {
            _notificationRepository.Create(notification);
        }

        public void Delete(Notification notification)
        {
            _notificationRepository.Delete(notification);
        }

        public IEnumerable<Notification> GetAll()
        {
            return _notificationRepository.GetAll();
        }

        public Notification GetById(Guid id)
        {
            return _notificationRepository.GetById(id);
        }

        public void Update(Notification notification)
        {
            _notificationRepository.Update(notification);
        }
    }
}
