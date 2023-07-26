using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly HospitalDbContext _context;

        public BlogRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public void Delete(Blog blog)
        {
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }

        public IEnumerable<Blog> GetAll()
        {
            return _context.Blogs.ToList();
        }

        public Blog GetById(Guid id)
        {
            return _context.Blogs.Find(id);
        }

        public void Update(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
