using System;

namespace HospitalAPI.Model
{
    public class Scheduling
    {
        public int Id { get; set; }
        private int DoctorId;
        private DateTime Start;
        private DateTime End;
        private Boolean Urgent;
    }
}