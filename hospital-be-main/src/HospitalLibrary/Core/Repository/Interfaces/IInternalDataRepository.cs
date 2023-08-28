using HospitalAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.Interfaces
{
    public interface IInternalDataRepository
    {
        IEnumerable<InternalData> GetAll();
        InternalData GetById(Guid id);
        void Create(InternalData iData);
        void Update(InternalData iData);
        void Delete(InternalData iData);
        List<InternalData> GetAllDatasForUser(Guid userId);
    }
}
