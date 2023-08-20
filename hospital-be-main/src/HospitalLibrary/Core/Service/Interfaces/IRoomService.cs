﻿using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAll();
        Room GetById(int id);
        void Create(Room room);
        void Update(Room room);
        void Delete(Room room);
    }
}
