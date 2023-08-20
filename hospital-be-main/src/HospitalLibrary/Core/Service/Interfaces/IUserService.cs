using System;
using System.Collections.Generic;
using HospitalAPI.DTO;
using HospitalAPI.Model;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IUserService
    {
        User GetUserWithEmail(string email);
        User Register(RegisterDTO dto);
        User UpdateProfile(User dto);
        User GetUserByID(long id);
        void Create(User user);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        void Update(User user);
        void Delete(User user);
        bool isEmailExist(string email);
        User Login(string email, string password);

        string Authenticate(string email, string password);
        bool EmailisUnique(string email);
        //User ChoseDoctor(User user, Guid doctorId);
        //IEnumerable<User> GetAllDoctors();


    }
}