using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class BloodBankNewsRepository : IBloodBankNewsRepository
    {
        private readonly HospitalDbContext _context;

        public BloodBankNewsRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BloodBankNews> GetAll()
        {
            return _context.BloodBankNews.ToList();
        }

        public void Create(BloodBankNews bloodBankNews)
        {
            _context.BloodBankNews.Add(bloodBankNews);
            _context.SaveChanges();
        }

        public List<BloodBankNews> GetPendingAndPublishNews()
        {
            return GetAll().Where(n => n.BloodBankNewsStatus != BloodBankNewsStatus.ARCHIVED).ToList();

        }

        public BloodBankNews GetById(Guid id)
        {
            return _context.BloodBankNews.Find(id);
        }

        public void Update(BloodBankNews news)
        {
            _context.Entry(news).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
