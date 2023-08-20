using HospitalAPI.Enum;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalLibrary.Core.Model
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid? DoctorId { get; private set; }
        public Guid? PatientId { get; private set; }
        public DateRange Range { get; private set; }
        public Priority Priority { get; private set; }
        public Status Status { get; set; }


        public Appointment() { }
        public Appointment(Guid id, Guid? doctorId, Guid? patientId, DateRange range, Priority piority, Status status)
        {
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            Range = range;
            Priority = piority;
            Status = status;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (DoctorId.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (PatientId.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (Range == null)
                throw new EntityObjectValidationFailedException();
        }

        public bool CheckDateRange()
        {
            var startRangeTime = Range.StartTime;
            var endRangeTime = Range.EndTime;

            if (startRangeTime < endRangeTime && DateTime.Now < startRangeTime)
                return true;

            return false;
        }



    }
}
