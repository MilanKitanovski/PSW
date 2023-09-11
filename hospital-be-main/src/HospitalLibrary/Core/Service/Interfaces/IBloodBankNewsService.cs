using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IBloodBankNewsService
    {
        List<BloodBankNews> GetPendingAndPublishNews();
        void Create(BloodBankNews bloodBankNews);
        void ArchiveNews(Guid id);
        void PublishNews(Guid id);
        BloodBankNews GetById(Guid id);

    }
}
