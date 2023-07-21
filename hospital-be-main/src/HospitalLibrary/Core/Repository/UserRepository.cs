using System.Collections.Generic;
using System.Linq;
using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
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

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User room)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User room)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserWithEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public bool isEmailExist(string email)
        {
            bool emailExist = _context.Users.Any(u => u.Email == email);
            return emailExist;
        }
    }
}