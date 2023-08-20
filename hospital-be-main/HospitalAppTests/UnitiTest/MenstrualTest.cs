using HospitalAPI.Enum;
using HospitalAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace HospitalAppTests.UnitiTest
{
    public class MenstrualTest
    {
       [Fact]
        public void Menstrual_Female_isNull()
        {
            Patient user = new Patient(Guid.NewGuid(), "Milana", "Kitanovski", /*new Email("Milana2000@gmail.com"), "123",*/ "0606060", Gender.Female);

            InternalData data = new InternalData(Guid.NewGuid(), user.Id, "5/1", 5.0, 5.0, 5.0, null);
            Assert.Throws<EntityObjectValidationFailedException>(() => data.MenstrualCheck(user, null));
        }

        [Theory] //Koristi se kad vec imamo definisane ulazne argumente
        [MemberData(nameof(Data))]
        public void MenstrualCheck(Patient user, DateRange dateRange)
        {
            InternalData data = new InternalData(Guid.NewGuid(),user.Id, "5/1", 5.0, 5.0, 5.0, dateRange);
            if(user.GenderUser.Equals(Gender.Male))
            {
                Assert.Throws<MaleCantMensruation>(() => {
                    data.MenstrualCheck(user, dateRange);
                });
            }
            Assert.Equal(dateRange, data.Menstrual);
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] {
                new Patient(Guid.NewGuid(), "Milana", "Kitanovski",/* new Email("Milana2000@gmail.com"), "123", */"0606060", Gender.Female),
                new DateRange(DateTime.Now, DateTime.Now.AddDays(8))
            },

             new object[] {
                new Patient(Guid.NewGuid(), "Milan", "Kitanovski", /*new Email("Milan2000@gmail.com"), "123", */"0606060", Gender.Male),
                new DateRange(DateTime.Now, DateTime.Now.AddDays(8))
            }

        }; 

    }
}
