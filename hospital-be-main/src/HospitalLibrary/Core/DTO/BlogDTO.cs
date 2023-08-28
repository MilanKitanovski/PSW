using HospitalLibrary.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class BlogDTO
    {
        public string TextBlog { get; set; }
        public BlogTheme Theme { get; set; }
    }
}
