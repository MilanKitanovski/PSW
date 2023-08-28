using AutoMapper;
using HospitalAPI.Model;
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
            CreateMap<DirectionDTO, Direction>();
            CreateMap<Direction, DirectionDTO>();
            CreateMap<ReportDTO, Report>();
            CreateMap<InternalDataDTO, InternalData>();
            CreateMap<InternalData, InternalDataDTO > ();
            CreateMap<BlogDTO, Blog>();
            CreateMap<Blog, BlogDTO>();
        }
    }
}
