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
        private readonly IPatientRepository _petientRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IPatientRepository patient)
        {
            _appointmentRepository = appointmentRepository;
            AppointmentDuration = new TimeSpan(0,30,0);
            _doctorRepository = doctorRepository;
            _petientRepository = patient;
        }

        public void FinishAppointment(Guid appointmentId)
        {
            var app = _appointmentRepository.GetById(appointmentId);
            app.FinishAppointment();
            Update(app);
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

        public bool CanceledAppointment(Guid appointmentId, Guid patientId)
        {
            Appointment appointment = _appointmentRepository.GetById(appointmentId);
            
            if(DateTime.Now.AddHours(48) > appointment.Range.StartTime)
            {
                return false;
            }
            
            appointment.CancelAppointment();
            _appointmentRepository.Update(appointment); 
            return true;
        }

        public List<SearchAppointmentResultDTO> SearchForPatientDoctor(SearchAppointmentDTO dto, Guid perosonId)
        {
            List<DateRange> dates = GetAppointmentsDateTime(dto.Range.StartTime, dto.Range.EndTime);
            List<SearchAppointmentResultDTO> result = new List<SearchAppointmentResultDTO>();

            Patient patient = _petientRepository.GetById(perosonId);
            var doctorId = patient.ChosenDoctorId;
            foreach (DateRange dr in dates)
            {
                if (GetAll().Any(a => a.DoctorId == doctorId && a.Status != Status.Canceled && a.Range.StartTime == dr.StartTime && a.Range.EndTime == dr.EndTime) == false) //da li ima neko ko je zakazao termin
                {
                    var doc = _doctorRepository.GetById(doctorId);
                    var FullName = doc.GetFullName();
                    result.Add(new SearchAppointmentResultDTO(doctorId, new DateRange(dr.StartTime, dr.EndTime), FullName));
                    return result; //lista u sebi ima samo jedan termin
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

        private List<DateRange> GetAppointmentsDateTime(DateTime start, DateTime end) //vraca sva vremena
        {
            List<DateRange> result = new List<DateRange>();
            start = start.Date + new TimeSpan(8, 0, 0); //pokupi datum i na datum veze vreme
            end = end.Date + new TimeSpan(16, 0, 0);
            //dt < end
            for (DateTime dt = start; dt <= end; dt = dt.Add(AppointmentDuration)) //krece od start date i ide do end date-a
            {
                if (CheckAppointmentTime(dt))
                {
                    result.Add(new DateRange(dt, dt.Add(AppointmentDuration)));
                }
                else
                {
                    dt = new DateTime(dt.Year, dt.Month, dt.Day, 8, 0, 0);
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
        public IEnumerable<Appointment> SearchAppointmentByDoctorPriority(SearchAppointmentDTO dto)
        {
            throw new NotImplementedException();
        }


        public List<SearchAppointmentResultDTO> SearchByDoctorsDirection(SpecializationSearchAppointmentDTO dto)
        {
            List<DateRange> dates = GetAppointmentsDateTime(dto.Range.StartTime, dto.Range.EndTime);
            List<SearchAppointmentResultDTO> result = new List<SearchAppointmentResultDTO>();

            foreach (DateRange dr in dates)
            {
                if (GetAll().Any(a => a.DoctorId == dto.DoctorId && a.Status == Status.Pending && a.Range.StartTime == dr.StartTime && a.Range.EndTime == dr.EndTime) == false) //da li ima neko ko je zakazao termin
                {
                    var doca = _doctorRepository.GetById(dto.DoctorId);
                    var FullName = doca.GetFullName();
                    result.Add(new SearchAppointmentResultDTO(dto.DoctorId, new DateRange(dr.StartTime, dr.EndTime), FullName));
                    return result; //lista u sebi ima samo jedan termin
                }
          
            }

            if(dto.Priority == Priority.DoctorPriority)
            {
                dates = GetAppointmentsDateTime(dto.Range.StartTime.AddDays(-7), dto.Range.EndTime.AddDays(7));
                foreach (DateRange dr in dates)
                {
                    if (GetAll().Any(a => a.DoctorId == dto.DoctorId && a.Status == Status.Pending && a.Range.StartTime == dr.StartTime && a.Range.EndTime == dr.EndTime) == false) //da li ima neko ko je zakazao termin
                    {
                        var doca = _doctorRepository.GetById(dto.DoctorId);
                        var FullName = doca.GetFullName();
                        result.Add(new SearchAppointmentResultDTO(dto.DoctorId, new DateRange(dr.StartTime, dr.EndTime), FullName));
                        return result;
                    }

                }

            }
            if (dto.Priority == Priority.TimePriority)
            {
                var doctors = _doctorRepository.getAllDoctorsBySpetialization(dto.Specialization);
                foreach (var doc in doctors)
                {
                    foreach (DateRange dr in dates)

                    {
                        if (GetAll().Any(a => a.DoctorId == doc.Id && a.Status != Status.Canceled && a.Range.StartTime == dr.StartTime && a.Range.EndTime == dr.EndTime) == false) //da li ima neko ko je zakazao termin
                        {
                            var doca = _doctorRepository.GetById(doc.Id);
                            var FullName = doca.GetFullName();
                            result.Add(new SearchAppointmentResultDTO(doc.Id, new DateRange(dr.StartTime, dr.EndTime), FullName));
                            return result; //lista u sebi ima samo jedan termin
                        }
                    }

                }
            }
           

            return result;
        }

        public List<Appointment> GetAllAppointmentsByDoctor(Guid doctorId)
        {
            return _appointmentRepository.GetAllAppointmentsByDoctor(doctorId);
        }

        public List<Appointment> GetAllAppointmentsByPatient(Guid personId)
        {
            return _appointmentRepository.GetAllAppointmentsByPatient(personId);
        }
    }
}
