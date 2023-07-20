using System.Collections.Generic;
using HospitalAPI.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(User room);
        void Update(User room);
        void Delete(User room);
        User GetUserWithEmail(string email);
        bool isEmailExist(string email);
    }
}