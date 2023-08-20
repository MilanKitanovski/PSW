using HospitalAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.Interfaces
{
    public interface IReportRepository
    {
        Report GetById(Guid id);
        void Create(Report report);
        void Delete(Report report);
        IEnumerable<Report> GetAllReportsFromUser(Guid id);
    }
}
