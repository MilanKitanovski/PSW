using HospitalAPI.Model;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class ReportService: IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public void Create(Report report)
        {
            _reportRepository.Create(report);
        }

        public void Delete(Report report)
        {
            _reportRepository.Delete(report);
        }

        public List<Report> GetAllReportsFromUser(Guid id)
        {
            return _reportRepository.GetAllReportsFromUser(id);
        }

        public Report GetById(Guid id)
        {
            return _reportRepository.GetById(id);
        }
    }
}
