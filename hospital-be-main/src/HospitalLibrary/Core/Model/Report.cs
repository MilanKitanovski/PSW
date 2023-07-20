using System;

namespace HospitalAPI.Model
{
    public class Report
    {
        public int Id { get; set; }
        private int DoctorId;
        private String Diagnosis;
        private String Treatment;
        private InternalData internalData;
    }
}