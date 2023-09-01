﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Exceptions
{
    public class UserIsNotBlockedException: Exception
    {
        public UserIsNotBlockedException(string message) : base(message) { }
    }
}
