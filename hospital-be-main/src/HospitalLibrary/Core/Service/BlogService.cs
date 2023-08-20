using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class BlogService: IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IDoctorRepository _doctorRepository;

        public BlogService(IBlogRepository blogRepository, IDoctorRepository doctorRepository)
        {
            _blogRepository = blogRepository;
            _doctorRepository = doctorRepository;
        }


        public Blog CreateBlog(Guid doctorId, string blogText)
        {
            /*   User user = _userRepository.GetById(doctorId); //uzmi trenutnog korisnika (doktora)

               Blog blog = _blogRepository.Create(doctorId, blogText);
               return blog;*/
            return null;
        }

        public IEnumerable<Blog> GetAll()
        {
            return _blogRepository.GetAll();
        }

        public Blog GetById(Guid id)
        {
            return _blogRepository.GetById(id);
        }

        public void Delete(Blog blog)
        {
            _blogRepository.Delete(blog);
        }
    }
}
