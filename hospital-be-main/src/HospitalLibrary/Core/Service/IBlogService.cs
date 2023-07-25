using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IBlogService
    {
        Blog CreateBlog(Guid doctorId, string blogText);
        IEnumerable<Blog> GetAll();

    }
}
