using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class ScheduleDTO
    {
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}
