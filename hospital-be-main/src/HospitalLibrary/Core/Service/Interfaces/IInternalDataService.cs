﻿using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IInternalDataService
    {
        IEnumerable<InternalData> GetAll();
        InternalData GetById(Guid id);
        void Create(InternalData data);
        void Update(InternalData data);
        void Delete(InternalData data);
        List<InternalData> GetAllDatasForUser(Guid userId);
    }
}
