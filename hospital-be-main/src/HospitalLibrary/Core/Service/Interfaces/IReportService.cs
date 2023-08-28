using HospitalAPI.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IReportService
    {
        void Delete(Report report);
        IEnumerable<Report> GetAllReportsFromUser(Guid id);
        Report GetById(Guid id);

        void Create(Report report);
    }
}
