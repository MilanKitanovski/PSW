using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;

namespace HospitalAPI.Model
{
    public class InternalData
    {
        public Guid Id { get; set; }
        public Guid? UserId;
        //validacija da je sve vece od 0
        public string BloodPressure { get; set; }
        public double BloodSugar { get; set; }
        public double Fats { get; set; }
        public double Weight { get; set; }

        public DateRange Menstrual { get; set; }

        public InternalData() { }

        public InternalData(Guid id, Guid? userId, string bloodPressure, double bloodSugar, double fats, double weight, DateRange menstrual)
        {
            Id = id;
            UserId = userId;
            BloodPressure = bloodPressure;
            BloodSugar = bloodSugar;
            Fats = fats;
            Weight = weight;
            Menstrual = menstrual;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (UserId.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(BloodPressure))
                throw new EntityObjectValidationFailedException();
            if (double.IsNaN(BloodSugar))
                throw new EntityObjectValidationFailedException();
            if (double.IsNaN(Fats))
                throw new EntityObjectValidationFailedException();
            if (double.IsNaN(Weight))
                throw new EntityObjectValidationFailedException();
        }

        public void MenstrualCheck(Patient user, DateRange dateRange)
        {
            if (user.GenderUser.Equals(Gender.Male))
            {
                throw new MaleCantMensruation();
            }

            if (Menstrual == null)
            {
                throw new EntityObjectValidationFailedException();
            }

            Menstrual = dateRange;
        }
    }
}