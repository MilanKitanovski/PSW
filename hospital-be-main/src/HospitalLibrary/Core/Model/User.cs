using System;
using HospitalAPI.Enum;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using HospitalLibrary.Exceptions;
using System.Runtime.CompilerServices;
using HospitalLibrary.Core.Model;
using System.Numerics;
using HospitalLibrary.Core.Enum;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Model
{
    public class User
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }
        public UserType UserType { get; set; }


        public Email Email { get;  set; }
   
        public string Password { get;  set; }
       

        public bool IsBlock = false;  

        public User() { }
        public User(Guid id, Guid personId, UserType userType, string email, string password)
        {
            Id = id;
            PersonId = personId;
            UserType = userType;
            Email = new Email(email);  
            Password = password;
            IsBlock = false;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException("Id is emtpy");
            if (Email == null)
                throw new EntityObjectValidationFailedException("Email is emtpy");
            if (string.IsNullOrEmpty(Password))
                throw new EntityObjectValidationFailedException("Password is emtpy");
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