﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Exceptions
{
    public class UserCanNotBeBlocked : Exception
   {
        public UserCanNotBeBlocked(string message) : base(message) { }
    }
}