using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(Guid id);
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        List<Doctor> getAllDoctor_Opste_Prakse();
        List<Doctor> getAllDoctorsBySpetialization(Specialization specialization);
    }
}
