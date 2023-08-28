using HospitalLibrary.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class DirectionDTO
    {
        public Guid PatientId { get; set; }
        public Specialization Specialization { get; set; }
    }
}
