﻿using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IBlogService
    {

        void Create(Blog blog);
        IEnumerable<Blog> GetAll();
        Blog GetById(Guid id);
        void Delete(Blog blog);


    }
}
