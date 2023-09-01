using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class InternalDataDTO
    {
        public Guid PatientId { get; set; }
        public string BloodPressure { get; set; }
        public double BloodSugar { get; set; }
        public double Fats { get; set; }
        public double Weight { get; set; }
        public DateRange Menstrual { get; set; }
    }
}
