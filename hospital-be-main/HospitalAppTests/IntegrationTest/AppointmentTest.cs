using Castle.Components.DictionaryAdapter;
using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppTests.IntegrationTest
{
    public class AppointmentTest
    {
        private AppointmentService _service;
        private AppointmentRepository _appointmentRepository;
        private DoctorRepository _doctorRepository;
        private AppointmentDTO appointmentDTO;
        public AppointmentTest() 
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _appointmentRepository = new AppointmentRepository(new HospitalDbContext(options));
            _doctorRepository = new DoctorRepository(new HospitalDbContext(options));
            _service = new AppointmentService(_appointmentRepository, _doctorRepository);

            _doctorRepository.Create(new Doctor(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Milana", "Kitanovski", "0606060", Specialization.Opsta_praksa));
            appointmentDTO = new AppointmentDTO(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new Guid("5ac33a84-628b-4183-a4e0-070e2aa3be8a"),
                 new DateRange(DateTime.Now, DateTime.Now.AddDays(1)));
        }

        [Fact]
        public void Get_all_appointments()
        {
            var result = _service.GetAll().Count();
            Assert.Equal("0", result.ToString());
        }

        [Fact]
        public void Search_For_Patient_Doctor()
        {
            var result = _service.SearchForPatientDoctor(appointmentDTO).Count().ToString();
            Assert.Equal("1", result); //vrati samo 1 termin - istestirali da li je vratio tacno 1 termin
        }

        [Fact]
        public void Search_For_Time_Priority()
        {
            var result = _service.SearchAppointmentByTimePriority(appointmentDTO);
            Assert.Equal("8:00 AM", result[0].Date.StartTime.ToShortTimeString());
        }

        [Fact]
        public void Cancle_Appointment_False()
        {
            var range = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0),
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0));
            _service.Create(new Appointment(new Guid("51e90a9f-6e03-4aa3-8572-83f989fc167e"), appointmentDTO.DoctorId, appointmentDTO.PatientId, range, Priority.TimePriority, 0));
            var result = _service.CanceledAppointment(new Guid("51e90a9f-6e03-4aa3-8572-83f989fc167e"));
            Assert.False(result);
        }

        [Fact]
        public void Cancle_Appointment_True()
        {
            var range = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(3),
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0).AddDays(3));
            _service.Create(new Appointment(new Guid("43e56ac2-5274-454a-9337-dc80aa545d13"), appointmentDTO.DoctorId, appointmentDTO.PatientId, range, Priority.TimePriority, 0));
            var result = _service.CanceledAppointment(new Guid("43e56ac2-5274-454a-9337-dc80aa545d13"));
            Assert.True(result);
        }

    }
}
