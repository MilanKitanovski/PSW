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
        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; }    
        //validacija da je sve vece od 0
        public string BloodPressure { get; set; }
        public double BloodSugar { get; set; }
        public double Fats { get; set; }
        public double Weight { get; set; }

        public DateRange Menstrual { get; set; }

        public InternalData() { }

        public InternalData(Guid id, Patient patient, string bloodPressure, double bloodSugar, double fats, double weight, DateRange menstrual)
        {
            Id = id;
            Patient = patient;
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
                throw new EntityObjectValidationFailedException("Id is empty");
            if(Patient == null)
                throw new EntityObjectValidationFailedException("Patient is null");
            if (string.IsNullOrEmpty(BloodPressure))
                throw new EntityObjectValidationFailedException("Blood pressure is empty");
            if (double.IsNaN(BloodSugar))
                throw new EntityObjectValidationFailedException("Blood sugar is empty");
            if(BloodSugar < 0.0)
                throw new EntityObjectValidationFailedException("Blood sugar cant be less then 0");
            if (double.IsNaN(Fats))
                throw new EntityObjectValidationFailedException("Fats is empty");
            if (Fats < 0.0)
                throw new EntityObjectValidationFailedException("Fats cant be less then 0");
            if (double.IsNaN(Weight))
                throw new EntityObjectValidationFailedException("Weight is empty");
            if (Weight < 0.0)
                throw new EntityObjectValidationFailedException("Weight cant be less then 0");
            MenstrualCheck();
        }

        private void MenstrualCheck()
        {
            if (Patient.GenderUser.Equals(Gender.Male)&& Menstrual!=null)
            {
                throw new MaleCantMensruation();
            }
       
        }
    }
}