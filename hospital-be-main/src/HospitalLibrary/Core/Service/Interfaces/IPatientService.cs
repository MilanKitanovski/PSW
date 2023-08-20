using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IPatientService
    {
        Patient RegisterPatient(Patient patient, Guid doctorId);

       // bool EmailisUnique(string email);

    }
}
