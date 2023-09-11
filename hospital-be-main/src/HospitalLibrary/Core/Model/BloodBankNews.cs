using HospitalLibrary.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class BloodBankNews
    {
        public Guid Id { get;private set; }
        public string NewsText { get;private set; }
        public BloodBankNewsStatus BloodBankNewsStatus { get;private set; }
        public BloodBankNews() { }

        public BloodBankNews(Guid id, string newsText)
        {
            Id = id;
            NewsText = newsText;
            BloodBankNewsStatus = BloodBankNewsStatus.PENDING;
        }

        public void StatusArhived()
        {
            BloodBankNewsStatus = BloodBankNewsStatus.ARCHIVED;
        }

        public void StatusPublished()
        {
            BloodBankNewsStatus = BloodBankNewsStatus.PUBLISHED;
        }
    }
}
