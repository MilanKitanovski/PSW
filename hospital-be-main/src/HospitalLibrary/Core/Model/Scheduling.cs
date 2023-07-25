using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using Microsoft.VisualBasic;
using System;

namespace HospitalAPI.Model
{
    public class Scheduling
    {
        public Guid Id { get; set; }
        public Guid? DoctorId;

        //mozda DateRange, da li nesto spada u taj date
        
        public DateRange DateInterval { get; private set; }

        public Boolean Urgent = false;

        public Scheduling() { }

        public Scheduling(Guid id, Guid? doctorId, DateRange dateInterval)
        {
            Id = id;
            DoctorId = doctorId;
            DateInterval = dateInterval;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (DoctorId.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (DateInterval == null)
                throw new EntityObjectValidationFailedException();
        }
    }
}