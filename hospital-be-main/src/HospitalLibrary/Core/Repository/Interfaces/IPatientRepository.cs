using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.Interfaces
{
    public interface IPatientRepository
    {
        void Create(Patient patient);
        public Patient GetById(Guid id);
    }
}
