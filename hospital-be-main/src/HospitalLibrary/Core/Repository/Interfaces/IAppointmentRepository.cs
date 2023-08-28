using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.Interfaces
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(Guid id);
        void Create(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(Appointment appointment);

        IEnumerable<Appointment> GetPandingAppointmentsByPatient(Guid patientId);
        IEnumerable<Appointment> GetFinishedAppointmentsByPatient(Guid patientId);
        IEnumerable<Appointment> GetCanceledAppointmentsByPatient(Guid patientId);

        List<Appointment> GetAllAppointmentsByDoctor(Guid doctorId);
        List<Appointment> GetAllAppointmentsByPatient(Guid personId);
    }
}

