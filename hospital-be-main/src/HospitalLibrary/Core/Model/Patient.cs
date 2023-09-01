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
    
        }



        public Guid ChosenDoctorId { get; private set; }
        public virtual Doctor ChosenDoctor { get; private set; }

        public void AppointTheChosenDoctor(Doctor doctor)
        {
            if(doctor == null)
                throw new EntityObjectValidationFailedException("Doctor is empty");
            if (doctor.Id == Guid.Empty)
                throw new EntityObjectValidationFailedException("Doctor Id is empty");

            ChosenDoctor = doctor;
            ChosenDoctorId = doctor.Id;
        }

    }
}
