using HospitalAPI.Model;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Shouldly;

namespace HospitalAppTests.UnitiTest
{
    public class InternalDataTests
    {

        [Fact]
        public void Menstrual_Female_DateRange_is_not_Null()
        {
            Patient patient = new Patient(Guid.NewGuid(), "Milana", "Kitanovski", "0606060", Gender.Female);
            DateRange dateRange = new DateRange(DateTime.Now, DateTime.Now.AddDays(8));

            InternalData idata = new InternalData(Guid.NewGuid(), patient, "pritisak", 21, 21, 21, dateRange);
            idata.ShouldNotBeNull();
        }
        [Fact]
        public void Menstrual_Female_DateRange_is_Null()
        {
            Patient patient = new Patient(Guid.NewGuid(), "Milana", "Kitanovski", "0606060", Gender.Female);
            InternalData idata = new InternalData(Guid.NewGuid(), patient, "pritisak", 21, 21, 21, null);
            idata.ShouldNotBeNull();
        }

        [Fact]
        public void Menstrual_Male_DateRange_is_Null()
        {
            Patient patient = new Patient(Guid.NewGuid(), "Milana", "Kitanovski", "0606060", Gender.Male);
            InternalData idata = new InternalData(Guid.NewGuid(), patient, "pritisak", 21, 21, 21, null);
            idata.ShouldNotBeNull();
        }
        [Fact]
        public void Menstrual_Male_DateRange_is_not_Null()
        {
            Patient patient = new Patient(Guid.NewGuid(), "Milana", "Kitanovski", "0606060", Gender.Male);
            DateRange dateRange = new DateRange(DateTime.Now, DateTime.Now.AddDays(8));
            Should.Throw<MaleCantMensruation>(() => (new InternalData(Guid.NewGuid(), patient, "pritisak", 21, 21, 21, dateRange)));
        }



    }
}
