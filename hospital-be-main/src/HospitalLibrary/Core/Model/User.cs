using System;
using HospitalAPI.Enum;
using Microsoft.VisualBasic;

namespace HospitalAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get;  set; }
        public String Surname { get;  set; }
        public String Email { get;  set; }
        public String Password { get;  set; }
        public String PhoneNumber { get;  set; }
        public UserType userType { get;  set; }
        public Boolean IsBlock { get;  set; } //{ get; private set; }
    }
}