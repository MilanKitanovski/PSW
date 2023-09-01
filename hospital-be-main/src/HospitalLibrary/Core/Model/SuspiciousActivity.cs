using HospitalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class SuspiciousActivity
    {
        public string ActivityName { get; private set; }
        public DateTime ActivityTime { get; private set; }

        public SuspiciousActivity(string activityName)
        {
            ActivityName = activityName;
            ActivityTime = DateTime.Now;
            Validate();
        }

        private void Validate()
        {

            if (string.IsNullOrEmpty(ActivityName))
            {
                throw new ValueObjectValidationFailedException("Activity name is empty");
            }
        }
    }
}
