using HospitalAPI.Enum;
using HospitalLibrary.Core.Enum;
using System;

namespace HospitalAPI.DTO
{
    public class RegisterDTO
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String PhoneNumber { get; set; }
        public Guid DoctorId { get; set; }
        public Gender Gender { get; set; }


    }
}