using System;
using HospitalAPI.Enum;
using Microsoft.VisualBasic;

namespace HospitalAPI.Model
{
    public class User
    {
        private String name;
        private String surname;
        private String email;
        private String password;
        private String City;
        private String Country;
        private UserType userType;
        private Boolean isBlock;
    }
}