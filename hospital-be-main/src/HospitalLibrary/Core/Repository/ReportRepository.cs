using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly HospitalDbContext _context;

        public ReportRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(Report report)
        {
            _context.Reports.Add(report);
            _context.SaveChanges();
        }

        public void Delete(Report report)
        {
            _context.Reports.Remove(report);
            _context.SaveChanges();
        }

        public Report GetById(Guid id)
        {
            return _context.Reports.Find(id);
        }

        public IEnumerable<Report> GetAllReportsFromUser(Guid userId)
        {
            return _context.Reports.Where(u => u.UserId == userId);
        }

    }
}
