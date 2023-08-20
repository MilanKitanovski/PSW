using HospitalLibrary.Core.DTO;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private TimeSpan AppointmentDuration;
        private readonly IDoctorRepository _doctorRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            AppointmentDuration = new TimeSpan(0,30,0);
            _doctorRepository = doctorRepository;
        }

        public void Create(Appointment appointment)
        {
            _appointmentRepository.Create(appointment);
        }

        public void Delete(Appointment appointment)
        {
            _appointmentRepository.Delete(appointment);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(Guid id)
        {
            return _appointmentRepository.GetById(id);
        }

        public IEnumerable<Appointment> GetCanceledAppointmentsByPatient(Guid patientId)
        {
            return _appointmentRepository.GetCanceledAppointmentsByPatient(patientId);
        }

        public IEnumerable<Appointment> GetFinishedAppointmentsByPatient(Guid patientId)
        {
            return _appointmentRepository.GetFinishedAppointmentsByPatient(patientId);
        }

        public IEnumerable<Appointment> GetPandingAppointmentsByPatient(Guid patientId)
        {
            return _appointmentRepository.GetPandingAppointmentsByPatient(patientId);
        }

        public void Update(Appointment appointment)
        {
             _appointmentRepository.Update(appointment);
        }

        public bool CanceledAppointment(Guid appointmentId)
        {
            Appointment appointment = _appointmentRepository.GetById(appointmentId);
            
            if(DateTime.Now.AddHours(48) > appointment.Range.StartTime)
            {
                return false;
            }

            appointment.Status = Status.Canceled;
            _appointmentRepository.Update(appointment);
            return true;
        }

        public List<ScheduleDTO> SearchForPatientDoctor(AppointmentDTO dto)
        {
            List<DateTime> dates = GetAppointmentsDateTime(dto.Range.StartTime, dto.Range.EndTime);
            List<ScheduleDTO> result = new List<ScheduleDTO>();

            foreach (DateTime dt in dates)
            {
                if (GetAll().Any(a => a.DoctorId == dto.DoctorId && a.Status != Status.Canceled && a.Range.StartTime == dt) == false) //da li ima neko ko je zakazao termin
                {
                    var doc = _doctorRepository.GetById(dto.DoctorId);
                    var FullName = doc.Specialization + " " + doc.Name + " " + doc.Surname;
                    result.Add(new ScheduleDTO(dto.DoctorId, new DateRange(dt, dt.Add(AppointmentDuration)), FullName));
                    return result; //lista u sebi ima samo jedan termin
                }
            }

            if(result.Count == 0) 
            {
                dto.Range.StartTime = FindStartDate(dto.Range.StartTime);
                dto.Range.EndTime = dto.Range.EndTime.AddDays(7);
                dates = GetAppointmentsDateTime(dto.Range.StartTime, dto.Range.EndTime);
                foreach (DateTime dt in dates)  //provera na +-7 dana
                {
                    if (GetAll().Any(a => a.DoctorId == dto.DoctorId && a.Status != Status.Canceled && a.Range.StartTime == dt) == false) //da li ima neko ko je zakazao termin
                    {
                        var doc = _doctorRepository.GetById(dto.DoctorId);
                        var FullName = doc.Specialization + " " + doc.Name + " " + doc.Surname; 
                        result.Add(new ScheduleDTO(dto.DoctorId, new DateRange(dt, dt.Add(AppointmentDuration)), FullName));
                    }
                }
            }

            return result;
        }   

        private DateTime FindStartDate(DateTime start)
        {
            for (int i = 7; i > 0; i--)
            {
                if (DateTime.Now <= start.AddDays(-i))
                {
                    start = start.AddDays(-i);
                    return start;
                }
            }
            return start;
 
        }

        private List<DateTime> GetAppointmentsDateTime(DateTime start, DateTime end) //vraca sva vremena
        {
            List<DateTime> result = new List<DateTime>();
            start = start.Date + new TimeSpan(8, 0, 0); //pokupi datum i na datum veze vreme
            end = end.Date + new TimeSpan(16, 0, 0); 
                                     //dt < end
            for(DateTime dt = start; dt <= end; dt = dt.Add(AppointmentDuration)) //krece od start date i ide do end date-a
            {
                if(CheckAppointmentTime(dt)) 
                {
                    result.Add(dt);
                }
                else
                {
                    dt = new DateTime(dt.Year, dt.Month, dt.Day, 8,0,0);
                    dt = dt.AddDays(1);
                }
            }
            return result;
        }

        public bool CheckAppointmentTime(DateTime dt) //provera da li moze da upadne u opseg radnog vremena - moguce vreme
        {
            if(dt.Hour >= 8 && dt.Hour < 16) 
            {
                return true;
            }
            return false;
        }


        //search preko uputa
        public IEnumerable<Appointment> SearchAppointmentByDoctorPriority(AppointmentDTO dto)
        {
            throw new NotImplementedException();
        }


        public List<ScheduleDTO> SearchAppointmentByTimePriority(AppointmentDTO dto)
        {
            List<DateTime> dates = GetAppointmentsDateTime(dto.Range.StartTime, dto.Range.EndTime);
            List<ScheduleDTO> result = new List<ScheduleDTO>();

            foreach (DateTime dt in dates)
            {
                if (GetAll().Any(a => a.DoctorId == dto.DoctorId && a.Status != Status.Canceled && a.Range.StartTime == dt) == false) //da li ima neko ko je zakazao termin
                {
                    var doca = _doctorRepository.GetById(dto.DoctorId);
                    var FullName = doca.Specialization + " " + doca.Name + " " + doca.Surname;
                    result.Add(new ScheduleDTO(dto.DoctorId, new DateRange(dt, dt.Add(AppointmentDuration)), FullName));
                    return result; //lista u sebi ima samo jedan termin
                }
            }


            if (result.Count == 0)
            {
                Doctor doctor = _doctorRepository.GetById(dto.DoctorId);
                foreach(Doctor doc in _doctorRepository.GetAll())
                {
                    if(doc.Specialization == doctor.Specialization)
                    {
                        foreach (DateTime dt in dates)  //provera na +-7 dana
                        {
                            if (GetAll().Any(a => a.DoctorId == doc.Id && a.Status != Status.Canceled && a.Range.StartTime == dt) == false) //da li ima neko ko je zakazao termin
                            {
                                var doca = _doctorRepository.GetById(dto.DoctorId);
                                var FullName = doca.Specialization + " " + doca.Name + " " +doca.Surname;
                                result.Add(new ScheduleDTO(doc.Id, new DateRange(dt, dt.Add(AppointmentDuration)), FullName));
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
