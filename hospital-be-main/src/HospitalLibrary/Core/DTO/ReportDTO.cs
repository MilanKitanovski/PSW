﻿using HospitalAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class ReportDTO
    {
        public Guid? DoctorId { get; set; }

        public Guid? UserId { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public InternalData InternalData { get; set; }
    }
}