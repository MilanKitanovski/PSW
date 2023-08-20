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
        public Guid? PatientId { get; set; }
        public Specialization Specialization { get; set; }
        public bool IsActive { get; set; }

        public Direction() { }

        public Direction(Guid id, Guid? patientId, Specialization specialization, bool isActive)
        {
            Id = id;
            PatientId = patientId;
            Specialization = specialization;
            IsActive = isActive;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (PatientId.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
        }
    }
}
