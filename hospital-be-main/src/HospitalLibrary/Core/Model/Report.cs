using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using Microsoft.Extensions.Options;
using System;

namespace HospitalAPI.Model
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public Guid InternalDataId { get; set; }
        public virtual InternalData InternalData { get; set; }

        public Guid AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }

        public Report() { }

        public Report(Guid id, Doctor doctor, string diagnosis, string treatment, InternalData internalData, Patient patient, Appointment appointment) 
        {
            Id = id;
            Doctor = doctor;
            Patient = patient;
            Diagnosis = diagnosis;
            Treatment = treatment;
            InternalData = internalData;
            Appointment = appointment;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException("Id is empty");
            if (string.IsNullOrEmpty(Diagnosis))
                throw new EntityObjectValidationFailedException("Diagnosis is emtpy");
            if (string.IsNullOrEmpty(Treatment))
                throw new EntityObjectValidationFailedException("Treatment is emtpy");
            if (InternalData == null)
                throw new EntityObjectValidationFailedException("InternalData is emtpy");
            if(Patient == null)
                throw new EntityObjectValidationFailedException("Patient is emtpy");
            if(Appointment == null)
                throw new EntityObjectValidationFailedException("Appointment is emtpy");
        }
    }
}