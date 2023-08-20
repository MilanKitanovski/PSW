using HospitalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalLibrary.Core.Model
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public Person(Guid id, string name, string surname, string phoneNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }
        private void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(Surname))
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(PhoneNumber))
                throw new EntityObjectValidationFailedException();
        }
    }
}
