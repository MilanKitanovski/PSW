using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
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
        private readonly IUserRepository _userRepository;

        public BlogService(IBlogRepository blogRepository, IUserRepository userRepository)
        {
            _blogRepository = blogRepository;
            _userRepository = userRepository;
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

    }
}
