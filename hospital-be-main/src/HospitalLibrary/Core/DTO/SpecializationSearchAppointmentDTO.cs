using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class SpecializationSearchAppointmentDTO
    {
        public Priority Priority { get; set; }
        public Specialization Specialization { get; set; }
        public Guid DoctorId { get; set; }
        public DateRange Range { get; set; }
    }
}
