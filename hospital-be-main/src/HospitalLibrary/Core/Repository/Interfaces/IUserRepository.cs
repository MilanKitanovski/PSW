using HospitalAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        User GetUserWithEmail(string email);
        bool isEmailExist(string email);
        User GetByEmail(string email);
        User GetByPersonId(Guid personId);
        IEnumerable<User> GetAllUserBySuspiciousActivity();
    }
}
