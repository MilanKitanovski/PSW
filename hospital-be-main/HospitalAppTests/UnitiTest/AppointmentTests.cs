using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppTests.UnitiTest
{
    public class AppointmentTests
    {

        [Fact]
        public void Check_Date_Range_true()
        {
            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, now.Day + 1, 8, 30, 0);
            DateTime endDate = new DateTime(now.Year, now.Month, now.Day + 3, 8, 30, 0);

            Doctor doctor = new Doctor(Guid.NewGuid(), "Doc", "Doc", "Doccc", Specialization.Opsta_praksa);
            Patient patient = new Patient(Guid.NewGuid(), "Milana", "Kitanovski", "0606060", Gender.Female);

            var appointment = new Appointment(Guid.NewGuid(), doctor, patient, new DateRange(startDate, endDate), Status.Pending);
            appointment.CheckDateRange().ShouldBeTrue();

        }

        [Fact]
        public void Check_Date_Range_false()
        {
            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, now.Day, 8, 30, 0);
            DateTime endDate = new DateTime(now.Year, now.Month, now.Day + 3, 8, 30, 0);

            Doctor doctor = new Doctor(Guid.NewGuid(), "Doc", "Doc", "Doccc", Specialization.Opsta_praksa);
            Patient patient = new Patient(Guid.NewGuid(), "Milana", "Kitanovski", "0606060", Gender.Female);

            var appointment = new Appointment(Guid.NewGuid(), doctor, patient, new DateRange(startDate, endDate), Status.Pending);
            appointment.CheckDateRange().ShouldBeFalse();
        }


    }
}
