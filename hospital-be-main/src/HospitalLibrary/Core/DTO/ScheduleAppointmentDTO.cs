using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class ScheduleAppointmentDTO
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateRange Range { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

        public ScheduleAppointmentDTO() { }

    }
}
