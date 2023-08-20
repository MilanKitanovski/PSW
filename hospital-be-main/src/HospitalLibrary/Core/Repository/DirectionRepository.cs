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
    public class DirectionRepository : IDirectionRepository
    {
        private readonly HospitalDbContext _context;

        public DirectionRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(Direction direction)
        {
            _context.Directions.Add(direction);
            _context.SaveChanges();
        }

        public void Delete(Direction direction)
        {
            _context.Directions.Remove(direction);
            _context.SaveChanges();
        }

        public IEnumerable<Direction> GetAll()
        {
            return _context.Directions.ToList();
        }

        public Direction GetById(Guid id)
        {
            return _context.Directions.Find(id);
        }

        public void Update(Direction direction)
        {
            _context.Entry(direction).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public IEnumerable<Direction> GetDirectionsByPatient(Guid id)
        {
            return _context.Directions.Where(x => x.PatientId == id);
        }
    }
}
