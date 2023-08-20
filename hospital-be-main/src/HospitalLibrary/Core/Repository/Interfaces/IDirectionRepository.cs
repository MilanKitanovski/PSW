using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.Interfaces
{
    public interface IDirectionRepository
    {
        IEnumerable<Direction> GetDirectionsByPatient(Guid id);
        IEnumerable<Direction> GetAll();
        Direction GetById(Guid id);
        void Create(Direction direction);
        void Update(Direction direction);
        void Delete(Direction direction);
    }
}
