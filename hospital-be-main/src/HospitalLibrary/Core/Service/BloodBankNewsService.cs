using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class BloodBankNewsService : IBloodBankNewsService
    {
        private readonly IBloodBankNewsRepository _bloodBankNewsRepository;

        public BloodBankNewsService(IBloodBankNewsRepository bloodBankNewsRepository)
        {
            _bloodBankNewsRepository = bloodBankNewsRepository;
        }
        public void Create(BloodBankNews bloodBankNews)
        {
            _bloodBankNewsRepository.Create(bloodBankNews);
        }

        public List<BloodBankNews> GetPendingAndPublishNews()
        {
            return _bloodBankNewsRepository.GetPendingAndPublishNews();
        }

        public void ArchiveNews(Guid id)
        {
            BloodBankNews news = _bloodBankNewsRepository.GetById(id);
            if (news == null)
            {
                throw new NotFoundException("Not Found");
            }
            news.StatusArhived();
            _bloodBankNewsRepository.Update(news);
        }

        public void PublishNews(Guid id)
        {
            BloodBankNews news = _bloodBankNewsRepository.GetById(id);
            if (news == null)
            {
                throw new NotFoundException("Not Found");
            }
            news.StatusPublished();
            _bloodBankNewsRepository.Update(news);
        }

        public BloodBankNews GetById(Guid id)
        {
            return _bloodBankNewsRepository.GetById(id);
        }
    }
}
