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
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public virtual Patient Patient { get; private set; }    
        public string BloodPressure { get; private set; }
        public double BloodSugar { get; private set; }
        public double Fats { get; private set; }
        public double Weight { get; private set; }

        public DateRange Menstrual { get; private set; }

        public DateTime TimeCreated { get; private set; }

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
            TimeCreated = DateTime.Now;
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
                throw new MaleCantMensruation("Male patient can not have menstruation");
            }
       
        }
    }
}