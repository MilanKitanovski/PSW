using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Admin : Person
    {
        public string MJAUUU { get; set; }
        public Admin(Guid id, string name, string surname, string phoneNumber, string mJAUUU) :
          base(id, name, surname, phoneNumber)
        {
            MJAUUU = mJAUUU;
        }
    }
}
