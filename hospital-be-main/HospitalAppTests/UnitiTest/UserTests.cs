using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Components.Web;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppTests.UnitiTest
{
    public class UserTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Appoint_The_Chosen_Doctor(Doctor doctor)
        {
            Patient patient = new Patient(Guid.NewGuid(), "Mirko", "Mirkovic", /* new Email("Mirko2000@gmail.com"), "123", */"0606060", Gender.Male);
            if(doctor == null)
            {
                Assert.Throws<EntityObjectValidationFailedException>(() => patient.AppointTheChosenDoctor(doctor));
            }
            else if (doctor.Id == Guid.Empty)
            {
                Assert.Throws<EntityObjectValidationFailedException>(() => patient.AppointTheChosenDoctor(doctor));
            }
            else
            {
                patient.AppointTheChosenDoctor(doctor);
                Assert.Equal(patient.ChosenDoctor, doctor);
            }
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]
            {
                new Doctor(Guid.NewGuid(), "Milana", "Kitanovski", /*new Email("Milana2000@gmail.com"), "123", */"0606060",Specialization.Opsta_praksa),
            },

            new object[]
            {
                null
            }
        };
    }
}
