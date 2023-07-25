using System;
using HospitalAPI.Enum;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using HospitalLibrary.Exceptions;
using System.Runtime.CompilerServices;
using HospitalLibrary.Core.Model;
using System.Numerics;

namespace HospitalAPI.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string Surname { get;  set; }
        public Email Email { get;  set; }
        //min vr 3
        //[MinLength(3)]
        public string Password { get;  set; }
        public string PhoneNumber { get;  set; }
        public UserType UserType { get;  set; } //{ get; private set; }
        public bool IsBlock = false;  

        public User() { }

        public User(Guid id, string name, string surname, Email email, string password, string phoneNumber, UserType userType)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;  
            Password = password;
            PhoneNumber = phoneNumber;
            UserType = UserType.Patient;
            IsBlock = false;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(Name))
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(Surname))
                throw new EntityObjectValidationFailedException();
            if (Email == null)
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(Password))
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(Password))
                throw new EntityObjectValidationFailedException();
            if (UserType == null)
                throw new EntityObjectValidationFailedException();
        }


        public User ChosenDoctor { get; set; }
        public Guid ChosenDoctorId { get; private set; }

        public void AppointTheChosenDoctor(User doctor)
        {
            if (doctor == null)
                throw new EntityObjectValidationFailedException();
            if (doctor.Id == Guid.Empty)
                throw new EntityObjectValidationFailedException();

            ChosenDoctor = doctor;
            ChosenDoctorId = doctor.Id;

        }

        public void Block()
        {
            if (IsBlock)
            {
                throw new UserIsAlreadyBlockedException();
            }

         /*   if (!HasEnoughSuspiciousActivities())
            {
                throw new UserCanNotBeBlocked();
            } */

            IsBlock = true;
        }

        public void Unblock()
        {
            if (!IsBlock)
            {
                throw new UserIsNotBlockedException();
            }
            IsBlock = false;
        }
    }
}