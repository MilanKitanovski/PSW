using System;
using System.Collections.Generic;
using HospitalAPI.DTO;
using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;


        public UserService( IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }
        
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(Guid id)
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

        public User Login(string email, string password)
        {
          
            return null;
        }

        public string Authenticate(string email, string password)
        {
            //Password enteredPassword = new Password(password);
            User user = _userRepository.GetUserWithEmail(email);

            if (user == null)
            {
                throw new NotFoundException();
            }

          

            if (!user.Password.Equals(password))
            {
                throw new BadPasswordException();
            }


            if (user.IsBlock)
            {
                throw new UserIsBlockedException();
            }

            return _jwtService.GenerateToken(user);
        }

        public bool isEmailUnique(String email)
        {
            if (_userRepository.GetByEmail(email) == null)
                return true;
            return false;
        }

        public User Register(RegisterDTO dto)
        {
                return null;
        }

/*        public User ChoseDoctor(User user, Guid doctorId)
        {
            var doctor = _userRepository.GetById(doctorId);
            user.AppointTheChosenDoctor(doctor);
            _userRepository.Create(user);
            return user;
        } */

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

        public bool EmailisUnique(string email)
        {
            if (_userRepository.GetByEmail(email) == null)
                return true;
            return false;
        }
        /*
        public IEnumerable<User> GetAllDoctors()
        {
            return _userRepository.GetAllDoctors();
        } */

    }
}