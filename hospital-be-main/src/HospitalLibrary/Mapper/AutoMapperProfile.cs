using AutoMapper;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ScheduleAppointmentDTO, Appointment>();
        }
    }
}
