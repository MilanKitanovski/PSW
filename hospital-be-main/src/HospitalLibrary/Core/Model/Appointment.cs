using HospitalLibrary.Core.Enum;
using HospitalLibrary.Exceptions;
using System;

namespace HospitalLibrary.Core.Model
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid DoctorId { get; private set; }
        public virtual Doctor Doctor { get; private set; }
        public Guid PatientId { get; private set; }
        public virtual Patient Patient { get; private set; }
        public DateRange Range { get; private set; }
        public Status Status { get; set; }


        public Appointment() { }

        public Appointment(Guid id, Doctor doctor, Patient patient, DateRange range, Status status)
        {
            Id = id;
            Doctor = doctor;
            Patient = patient;
            Range = range;
            Status = status;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException("Id is empty");
            if (Doctor == null)
                throw new EntityObjectValidationFailedException("Doctor is null");
            if (Patient == null)
                throw new EntityObjectValidationFailedException("Patient is null");
            if (Range == null)
                throw new EntityObjectValidationFailedException("Range is null");
        }

        public bool CheckDateRange()
        {
            var startRangeTime = Range.StartTime;
            var endRangeTime = Range.EndTime;

            if (startRangeTime < endRangeTime && DateTime.Now < startRangeTime)
                return true;

            return false;
        }

        public void FinishAppointment()
        {
            Status = Status.Finished;
        }


    }
}
