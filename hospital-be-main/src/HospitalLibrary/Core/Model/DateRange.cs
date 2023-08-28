using HospitalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class DateRange
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public DateRange() { }

        public DateRange(DateTime startTime, DateTime endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            Validate();
        }

        private void Validate()
        {
            if(this.StartTime > this.EndTime)
                throw new ValueObjectValidationFailedException("Start date shoud be end date");

        }

        public Boolean OverlapsWith(DateRange dateRange)
        {
            // starts in interval
            // ends in interval
            // overshadows interval
            return (this.StartTime <= dateRange.StartTime && this.EndTime > dateRange.StartTime) ||
                    (this.StartTime < dateRange.EndTime && this.EndTime >= dateRange.EndTime) ||
                    (this.StartTime >= dateRange.StartTime && this.EndTime < dateRange.EndTime);
        }

          public Boolean IsLesserThan(DateTime time) {
            return this.EndTime < time;
        }
    }
}
