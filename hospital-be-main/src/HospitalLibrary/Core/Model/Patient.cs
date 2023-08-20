using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Patient: Person
    {
        public Gender GenderUser { get; private set; }
        public Patient(Guid id, string name, string surname, string phoneNumber, Gender genderUser) : 
            base(id, name, surname, phoneNumber )
        {
            GenderUser = genderUser;
            Validate();
        }

        private void Validate()
        {
            if (GenderUser == null)
                throw new EntityObjectValidationFailedException();
        }

        public Doctor ChosenDoctor { get; set; }
        public Guid ChosenDoctorId { get; private set; }

        public void AppointTheChosenDoctor(Doctor doctor)
        {
            if(doctor == null)
                throw new EntityObjectValidationFailedException();
            if (doctor.Id == Guid.Empty)
                throw new EntityObjectValidationFailedException();

            ChosenDoctor = doctor;
            ChosenDoctorId = doctor.Id;
        }

    }
}
