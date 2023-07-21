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
        public double BloodPressure { get; set; }
        public double BloodSugar { get; set; }
        public double Fats { get; set; }
        public double Weight { get; set; }

        public InternalData() { }

        public InternalData(Guid id, Guid? userId, double bloodPressure, double bloodSugar, double fats, double weight)
        {
            Id = id;
            UserId = userId;
            BloodPressure = bloodPressure;
            BloodSugar = bloodSugar;
            Fats = fats;
            Weight = weight;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (UserId.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (double.IsNaN(BloodPressure))
                throw new EntityObjectValidationFailedException();
            if (double.IsNaN(BloodSugar))
                throw new EntityObjectValidationFailedException();
            if (double.IsNaN(Fats))
                throw new EntityObjectValidationFailedException();
            if (double.IsNaN(Weight))
                throw new EntityObjectValidationFailedException();

        }
    }
}