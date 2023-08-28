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
    public class AdminRepository : IAdminRepository
    {
        private readonly HospitalDbContext _context;

        public AdminRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Admin GetById(Guid id)
        {
            return _context.Admins.Find(id);
        }
    }
}
