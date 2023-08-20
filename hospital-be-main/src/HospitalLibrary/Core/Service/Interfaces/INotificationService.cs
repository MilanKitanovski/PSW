using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface INotificationService
    {
        IEnumerable<Notification> GetAll();
        Notification GetById(Guid id);
        void Create(Notification notification);
        void Update(Notification notification);
        void Delete(Notification notification);
    }
}
