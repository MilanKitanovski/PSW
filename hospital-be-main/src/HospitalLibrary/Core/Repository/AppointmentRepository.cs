using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        public AppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }


        public void Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public Appointment GetById(Guid id)
        {
            return _context.Appointments.Find(id);
        }

        public IEnumerable<Appointment> GetPandingAppointmentsByPatient(Guid patientId)
        {
            return _context.Appointments.Where(a => a.PatientId == patientId && a.Status == Status.Pending);
        }

        public IEnumerable<Appointment> GetFinishedAppointmentsByPatient(Guid patientId)
        {
            return _context.Appointments.Where(a => a.PatientId == patientId && a.Status == Status.Finished);
        }

        public IEnumerable<Appointment> GetCanceledAppointmentsByPatient(Guid patientId)
        {
            return _context.Appointments.Where(a => a.PatientId == patientId && a.Status == Status.Canceled);
        }

        public List<Appointment> GetAllAppointmentsByDoctor(Guid doctorId)
        {
            return _context.Appointments.Where(a => a.DoctorId == doctorId).ToList();
        }

        public List<Appointment> GetAllAppointmentsByPatient(Guid personId)
        {
            return _context.Appointments.Where(a => a.PatientId == personId).ToList();
        }

        public void Update(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


    }
}
