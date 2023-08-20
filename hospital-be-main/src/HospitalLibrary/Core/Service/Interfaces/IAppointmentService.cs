using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(Guid id);
        void Create(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(Appointment appointment);
        IEnumerable<Appointment> GetPandingAppointmentsByPatient(Guid patientId);
        IEnumerable<Appointment> GetFinishedAppointmentsByPatient(Guid patientId);
        IEnumerable<Appointment> GetCanceledAppointmentsByPatient(Guid patientId);
        IEnumerable<Appointment> SearchAppointmentByDoctorPriority(AppointmentDTO dto);
        List<ScheduleDTO> SearchAppointmentByTimePriority(AppointmentDTO dto);
        List<ScheduleDTO> SearchForPatientDoctor(AppointmentDTO dto);
        bool CanceledAppointment(Guid appointmentId);

        bool CheckAppointmentTime(DateTime dt);
    }
}
