using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Exceptions
{
    public class InvalidJwtException: Exception
    {
        public InvalidJwtException(string message) : base(message) { }
    }
}
