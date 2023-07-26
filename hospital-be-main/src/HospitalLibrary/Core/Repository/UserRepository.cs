using System;
using System.Collections.Generic;
using System.Linq;
using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HospitalDbContext _context;

        public UserRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new System.NotImplementedException();
        }
        /*
                public User GetUserWithEmail(string email)
                {
                    return _context.Users.FirstOrDefault(u => u.Email == email);
                }
        */
        public User GetByUsername(string username)
        {
            var result = _context.Users.Find(username);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public User GetUserWithEmail(string email)
        {
            var result = _context.Users.Find(email);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public bool isEmailExist(string email)
        {
            throw new System.NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(p => p.Email.Address.Equals(email));
        }


        public IEnumerable<User> GetAllDoctors()
        {
            return _context.Users.Where(d => d.UserType==UserType.Doctor);
        }

        /*
        public bool isEmailExist(string email)
        {
            bool emailExist = _context.Users.Any(u => u.Email == email);
            return emailExist;
        } */
    }
}