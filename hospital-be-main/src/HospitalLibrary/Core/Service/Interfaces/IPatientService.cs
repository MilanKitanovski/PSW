using HospitalLibrary.Core.Model;
using System;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IPatientService
    {
        Patient RegisterPatient(Patient patient, Guid doctorId);
        Patient GetById(Guid id);


    }
}
