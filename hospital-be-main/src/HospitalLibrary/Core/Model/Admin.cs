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
        public Admin(Guid id, string name, string surname, string phoneNumber) :
          base(id, name, surname, phoneNumber)
        {

        }
    }
}
