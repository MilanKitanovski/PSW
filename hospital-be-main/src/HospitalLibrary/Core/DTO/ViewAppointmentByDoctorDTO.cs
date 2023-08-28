using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class ViewAppointmentByDoctorDTO
    {
        public string PatientName { get; set; }
        public Guid AppointmentId { get; set; }
        public DateRange Date { get; set; }

        public ViewAppointmentByDoctorDTO(Appointment app)
        {
            Date = app.Range;
            AppointmentId = app.Id;
            PatientName = app.Patient.Name + ' ' + app.Patient.Surname;
        }
    }
}
