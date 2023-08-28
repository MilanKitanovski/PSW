using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Doctor : Person
    {
        public Specialization Specialization { get; private set; }
        public Doctor(Guid id, string name, string surname, string phoneNumber, Specialization specialization) : 
            base(id, name, surname, phoneNumber)
        {
            Specialization = specialization;
        }

        internal string GetFullName()
        {
            return Name + " - " + Surname;
        }
    }
}
