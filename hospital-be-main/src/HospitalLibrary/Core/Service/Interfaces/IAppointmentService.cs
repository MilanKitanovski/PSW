using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
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
        IEnumerable<Appointment> SearchAppointmentByDoctorPriority(SearchAppointmentDTO dto);
        List<SearchAppointmentResultDTO> SearchByDoctorsDirection(SpecializationSearchAppointmentDTO dto);
        List<SearchAppointmentResultDTO> SearchForPatientDoctor(SearchAppointmentDTO dto, Guid personId);
        bool CanceledAppointment(Guid appointmentId);
        List<Appointment> GetAllAppointmentsByDoctor(Guid doctorId);

        void FinishAppointment(Guid appointmentId);

        bool CheckAppointmentTime(DateTime dt);
    }
}
