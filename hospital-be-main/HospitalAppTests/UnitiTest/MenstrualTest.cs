using HospitalAPI.Enum;
using HospitalAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Enum;

namespace HospitalAppTests.UnitiTest
{
    public class MenstrualTest
    {
        [Fact]
        public void Menstrual_Male()
        {
            User user = new User("Milan", "Kitanovski", new Email("Milan2000@gmail.com"), "123", "0606060" ,UserType.Patient, Gender.Male);
            InternalData data = new InternalData(user.Id, 5, 5, 5, 5, null);
        }

        [Fact]
        public void Menstrual_Female()
        {
            User user = new User("Milana", "Kitanovski", new Email("Milana2000@gmail.com"), "123", "0606060", UserType.Patient, Gender.Female);
            InternalData data = new InternalData(user.Id, 5, 5, 5, 5, null);
        }

    }
}
