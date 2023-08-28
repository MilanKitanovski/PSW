using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class DirectionService : IDirectionService
    {
        private readonly IDirectionRepository _directionRepository;

        public DirectionService(IDirectionRepository directionRepository)
        {
            _directionRepository = directionRepository;
        }

        public void Create(Direction direction)
        {
            _directionRepository.Create(direction);
        }

        public void Delete(Direction direction)
        {
            _directionRepository.Delete(direction);
        }

        public IEnumerable<Direction> GetAll()
        {
            return _directionRepository.GetAll();
        }

        public Direction GetById(Guid id)
        {
            return _directionRepository.GetById(id);
        }

        public void Update(Direction direction)
        {
            _directionRepository.Update(direction);
        }

        public List<Direction> GetDirectionsByPatient(Guid id)
        {
            return _directionRepository.GetDirectionsByPatient(id);
        }
    }
}
