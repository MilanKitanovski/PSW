using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class ScheduleDTO
    {
        private readonly IDoctorService _doctorService;

        public ScheduleDTO(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public Guid DoctorId { get; set; }
        public DateRange Date { get; set; }

        public string FullName { get; set; }

        public ScheduleDTO() { }

        public ScheduleDTO(Guid doctorId, DateRange date, string fullName)
        {
            DoctorId = doctorId;
            Date = date;
            FullName = fullName;
        }
    }
}
