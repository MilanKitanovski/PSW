using HospitalLibrary.Exceptions;
using Microsoft.Extensions.Options;
using System;

namespace HospitalAPI.Model
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid? DoctorId { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public InternalData InternalData { get; set; }

        public Report() { }

        public Report(Guid id, Guid? doctorId, string diagnosis, string treatment, InternalData internalData) 
        {
            Id = id;
            DoctorId = doctorId;
            Diagnosis = diagnosis;
            Treatment = treatment;
            InternalData = internalData;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (DoctorId.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(Diagnosis))
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(Treatment))
                throw new EntityObjectValidationFailedException();
            if (InternalData == null)
                throw new EntityObjectValidationFailedException();
        }
    }
}