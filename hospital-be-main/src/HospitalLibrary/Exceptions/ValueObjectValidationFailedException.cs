using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Exceptions
{
    public class ValueObjectValidationFailedException: Exception
    {
        public ValueObjectValidationFailedException() { }

        public ValueObjectValidationFailedException(string message) : base(message) { }
    }
}
