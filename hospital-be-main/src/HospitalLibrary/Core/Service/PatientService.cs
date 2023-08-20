using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class PatientService : IPatientService
    {

        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        public PatientService(IPatientRepository patientRepository, IDoctorRepository doctorRepository)
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public Patient RegisterPatient(Patient patient, Guid doctorId)
        {
            var doctor = _doctorRepository.GetById(doctorId);
            patient.AppointTheChosenDoctor(doctor);
            _patientRepository.Create(patient);
            return patient;
        }

        /*
        public bool EmailisUnique(string email)
        {
            if (_patientRepository.GetByEmail(email) == null)
                return true;
            return false;
        } */

    }
}
