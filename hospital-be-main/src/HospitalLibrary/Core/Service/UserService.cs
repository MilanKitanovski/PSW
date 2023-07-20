using System;
using System.Collections.Generic;
using HospitalAPI.DTO;
using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Service
{
    public class UserService : IUserService
    {
        private readonly HospitalDbContext _hospitalDbContext;
        private readonly IUserRepository _userRepository;

        public UserService(HospitalDbContext hospitalDbContext, IUserRepository userRepository)
        {
            _hospitalDbContext = hospitalDbContext;
            _userRepository = userRepository;
        }
        
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetUserWithEmail(string email)
        {
            return _userRepository.GetUserWithEmail(email);
        }

        public bool isEmailExist(string email)
        {
            return _userRepository.isEmailExist(email);
        }
        
        public User Register(RegisterDTO dto)
        {
            try
            {
                var user = new User();

                user.Name = dto.Name;
                user.Surname = dto.Surname;
                user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
                user.Email = dto.Email;
                user.PhoneNumber = dto.PhoneNumber;
                user.userType = UserType.Patient;
                _userRepository.Create(user);

                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public User UpdateProfile(User dto)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByID(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }
    }
}