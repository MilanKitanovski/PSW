using HospitalAPI.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalLibrary.Core.Service
{
    public class InternalDataService : IInternalDataService
    {

        private readonly IInternalDataRepository _internalDataRepository;
        private readonly IUserRepository _userRepository;

        public InternalDataService(IInternalDataRepository internalDataRepository, IUserRepository userRepository)
        {
            _internalDataRepository = internalDataRepository;
            _userRepository = userRepository;
        }

        public void Create(InternalData iData)
        {
            _internalDataRepository.Create(iData);
        }

        public void Delete(InternalData iData)
        {
            _internalDataRepository.Delete(iData);
        }

        public IEnumerable<InternalData> GetAll()
        {
            return _internalDataRepository.GetAll();
        }

        public InternalData GetById(Guid id)
        {
            return _internalDataRepository.GetById(id);
        }

        public void Update(InternalData iData)
        {
            _internalDataRepository.Update(iData);
        }

        public List<InternalData> GetAllDatasForUser(Guid userId)
        {
            return _internalDataRepository.GetAllDatasForUser(userId);
        }
    }
}
