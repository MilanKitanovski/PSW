using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.Interfaces
{
    public interface IBloodBankNewsRepository
    {
        List<BloodBankNews> GetPendingAndPublishNews();

        void Create(BloodBankNews bloodBankNews);

        void Update(BloodBankNews appointment);
        BloodBankNews GetById(Guid id);


    }
}
