using System;
using System.Collections.Generic;
using HospitalAPI.Model;

namespace HospitalLibrary.Core.Repository
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
    }
}