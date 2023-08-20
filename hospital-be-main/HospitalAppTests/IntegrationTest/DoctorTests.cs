using AutoMapper.Execution;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Repository.Interfaces;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppTests.IntegrationTest
{
    public class DoctorTests
    {
        private BlogService _blogService;
        private BlogRepository _blogRepository;
        private DoctorRepository _doctorRepository;

        public DoctorTests() 
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _blogRepository = new BlogRepository(new HospitalDbContext(options));
            _doctorRepository = new DoctorRepository(new HospitalDbContext(options));
            _blogService = new BlogService(_blogRepository, _doctorRepository);
        }
    }
}
