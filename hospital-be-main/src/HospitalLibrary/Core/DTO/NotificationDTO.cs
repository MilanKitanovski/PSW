using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class NotificationDTO
    {
        public Guid? AdminId { get; set; }
        public string TextNotification { get; set; }
    }
}
