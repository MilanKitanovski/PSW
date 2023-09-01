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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HospitalAPI.Model
{
    public class User
    {
        public Guid Id { get; private set; }

        public Guid PersonId { get; private set; }
        public UserType UserType { get; private set; }


        public Email Email { get; private set; }
   
        public string Password { get; private set; }
       

        public bool IsBlock  { get; private set; }

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


        [Column(TypeName = "jsonb")] private List<SuspiciousActivity> suspicious_activities;

        public List<SuspiciousActivity> SuspiciousActivities
        {
            get
            {
                suspicious_activities ??= new List<SuspiciousActivity>();
                return new List<SuspiciousActivity>(suspicious_activities);
            }
            set { }

        }

        public void AddSuspiciousActivity(SuspiciousActivity suspiciousActivity)
        {
            suspicious_activities ??= new List<SuspiciousActivity>();
            suspicious_activities.Add(suspiciousActivity);
        }


        public bool HasEnoughSuspiciousActivities()
        {

            return HospitalLibrary.Core.Model.Constants.MinSuspiciousActivityCount <= NumberOfSuspiciousActivitiesInRecentPeriod();
        }

        public int NumberOfSuspiciousActivitiesInRecentPeriod()
        {
            return SuspiciousActivities.Count(suspiciousActivity => suspiciousActivity.ActivityTime >= DateTime.Now.AddDays(-HospitalLibrary.Core.Model.Constants.SuspiciousActivityPeriodDaysCheck));

        }

        public void Block()
        {
            if (IsBlock)
            {
                throw new UserIsAlreadyBlockedException("User is alredy blocked");
            }

            if (!HasEnoughSuspiciousActivities())
            {
                throw new UserCanNotBeBlocked("User can not be blocked");
            } 

            IsBlock = true;
        }

        public void Unblock()
        {
            if (!IsBlock)
            {
                throw new UserIsNotBlockedException("User is not blocked");
            }
            IsBlock = false;
        }

        public bool IsUserSuspicious()
        {
            return IsBlock || HasEnoughSuspiciousActivities();
        }

    }
}