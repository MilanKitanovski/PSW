using HospitalLibrary.Core.Model;
using System;

namespace HospitalLibrary.Core.DTO
{
    public class ScheduleAppointmentDTO
    {
        public Guid DoctorId { get; set; }
        public DateRange Range { get; set; }

        public ScheduleAppointmentDTO() { }

    }
}
