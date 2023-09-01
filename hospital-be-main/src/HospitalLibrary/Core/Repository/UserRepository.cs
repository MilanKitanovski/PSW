using System;
using System.Collections.Generic;
using System.Linq;
using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

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
            return _context.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public User GetByPersonId(Guid personId)
        {
            var user = _context.Users.SingleOrDefault(u => u.PersonId == personId);
            if (user == null)
            {
                throw new NotFoundException("Not Found");
            }

            return user;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            try
            {

            _context.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception("Email is not unique");
            }
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
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
                throw new NotFoundException("Not Found");
            }
            return result;
        }

        public User GetUserWithEmail(string email)
        {
            return _context.Set<User>().SingleOrDefault(u => u.Email.Address == email);

        }

        public bool isEmailExist(string email)
        {
            throw new System.NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(p => p.Email.Address.Equals(email));
        }

        public IEnumerable<User> GetAllUserBySuspiciousActivity()
        {
            return GetAll().Where(a => a.IsUserSuspicious());
        }



    }
}