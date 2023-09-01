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
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PhoneNumber { get; private set; }

        public Person(Guid id, string name, string surname, string phoneNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Validate();
        }
        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException("Id is empty");
            if (string.IsNullOrEmpty(Name))
                throw new EntityObjectValidationFailedException("Name is empty");
            if (string.IsNullOrEmpty(Surname))
                throw new EntityObjectValidationFailedException("Surname is empty");
            if (string.IsNullOrEmpty(PhoneNumber))
                throw new EntityObjectValidationFailedException("PhoneNumber is empty");
        }
    }
}
