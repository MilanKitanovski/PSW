﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class JwtDto
    {
        public string Jwt { get; set; }

        public JwtDto(string jwt)
        {
            Jwt = jwt;
        }
    }
}
