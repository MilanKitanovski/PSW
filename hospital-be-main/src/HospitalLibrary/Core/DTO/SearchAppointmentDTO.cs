using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class SearchAppointmentDTO
    {
        public Guid DoctorId { get; set; }
        public DateRange Range { get; set; }

        public SearchAppointmentDTO(Guid doctorId, DateRange range)
        {
            DoctorId = doctorId;
            Range = range;
        }
        public SearchAppointmentDTO() { }
    }
}
