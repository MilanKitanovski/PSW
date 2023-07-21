using HospitalLibrary.Exceptions;
using System;

namespace HospitalAPI.Model
{
    public class Scheduling
    {
        public Guid Id { get; set; }
        public Guid? DoctorId;

        //mozda DateRange, da li nesto spada u taj date
        public DateTime Start { get; set; }
        public DateTime End { get ; set; }
        public Boolean Urgent = false;

        public Scheduling() { }

        public Scheduling(Guid id, Guid? doctorId, DateTime start, DateTime end)
        {
            Id = id;
            DoctorId = doctorId;
            Start = start;
            End = end;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (DoctorId.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (Start == null)
                throw new EntityObjectValidationFailedException();
            if (End == null)
                throw new EntityObjectValidationFailedException();
        }
    }
}