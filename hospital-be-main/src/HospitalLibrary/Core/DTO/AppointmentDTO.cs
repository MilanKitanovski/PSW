using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class AppointmentDTO
    {
        public Guid DoctorId { get; set; }
        public Guid? PatientId { get; set; }
        public DateRange Range { get; set; }

        public AppointmentDTO(Guid doctorId, Guid? patientId, DateRange range)
        {
            DoctorId = doctorId;
            PatientId = patientId;
            Range = range;
        }
    }
}
