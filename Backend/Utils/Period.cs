using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils
{
    public class Period
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Period() {}

        public Period(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime; 
            EndTime = endTime;
        }
    }
}
