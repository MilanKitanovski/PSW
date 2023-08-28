using HospitalAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class ReportForPatientView
    {
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        
        public ReportForPatientView(Report report) 
        {
            Diagnosis = report.Diagnosis;
            Treatment = report.Treatment;
        }
    }
}
