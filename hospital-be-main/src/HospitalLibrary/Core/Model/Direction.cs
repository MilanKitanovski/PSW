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
    public class Direction
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public Specialization Specialization { get; set; }
        public bool IsActive { get; set; }

        public Direction() { }

        public Direction(Guid id, Patient patient, Specialization specialization)
        {
            Id = id;
            Patient = patient;
            Specialization = specialization;
            IsActive = true;
            Validate();
        }

        public void UsedToScheduleAppointment()
        {
            IsActive = false;
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException("Id is empty");
            if (Patient == null)
                throw new EntityObjectValidationFailedException("Patient is null");
        }
    }
}
