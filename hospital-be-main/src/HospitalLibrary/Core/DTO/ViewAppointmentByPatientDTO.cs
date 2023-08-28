using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class ViewAppointmentByPatientDTO
    {
        public Status Status { get; set; }
        public string DoctorName { get; set; }
        public Guid AppointmentId { get; set; }
        public DateRange Date { get; set; }

        public ViewAppointmentByPatientDTO(Appointment app)
        {
            Status = app.Status;
            Date = app.Range;
            AppointmentId = app.Id;
            DoctorName = app.Doctor.GetFullName();
        }
    }
}
