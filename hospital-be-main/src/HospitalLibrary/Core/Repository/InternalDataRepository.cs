using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class InternalDataRepository : IInternalDataRepository
    {
        private readonly HospitalDbContext _context;

        public InternalDataRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(InternalData iData)
        {
            _context.InternalDatas.Add(iData);
            _context.SaveChanges();
        }

        public void Delete(InternalData iData)
        {
            _context.InternalDatas.Remove(iData);
            _context.SaveChanges();
        }

        public IEnumerable<InternalData> GetAll()
        {
            return _context.InternalDatas.ToList();
        }

        public InternalData GetById(Guid id)
        {
            return _context.InternalDatas.Find(id);
        }

        public void Update(InternalData iData)
        {
            _context.Entry(iData).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public List<InternalData> GetAllDatasForUser(Guid userId)
        {
            List<InternalData> dataList = _context.InternalDatas.Where(u => u.PatientId == userId).ToList();
            dataList = dataList.OrderBy(data => data.TimeCreated).ToList();
            return dataList;

        }

    }
}
