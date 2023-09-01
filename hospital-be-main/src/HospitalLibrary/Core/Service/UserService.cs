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

        public void BlockUser(Guid id)
        {
            User user = _userRepository.GetById(id);
            if(user == null)
            {
                throw new NotFoundException("Not Found");
            }
            user.Block();
            _userRepository.Update(user);

        }
        public string Authenticate(string email, string password)
        {
            //Password enteredPassword = new Password(password);
            User user = _userRepository.GetUserWithEmail(email);

            if (user == null)
            {
                throw new NotFoundException("Not Found");
            }

          

            if (!user.Password.Equals(password))
            {
                throw new BadPasswordException("Bad Password");
            }


            if (user.IsBlock)
            {
                throw new UserIsBlockedException("User is blocked");
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

        public void AddSuspiciousActivityToUser(Guid personId, SuspiciousActivity suspiciousActivity)
        {
            User user = _userRepository.GetByPersonId(personId);
            user.AddSuspiciousActivity(suspiciousActivity);

            _userRepository.Update(user);
        }

        public IEnumerable<User> GetAllUserBySuspiciousActivity()
        {
            return _userRepository.GetAllUserBySuspiciousActivity();
        }

        public void Unblock(Guid id)
        {
            User user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new NotFoundException("Not Found");
            }
            user.Unblock();
            _userRepository.Update(user);
        }
    }
}