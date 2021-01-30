using MedbayTech.Common.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Common.Domain.ValueObjects
{
    public class Period : ValueObject
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Period()
        {
        }

        public Period(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public bool IsPeriodActive()
        {
            return StartTime.Date.CompareTo(EndTime.Date) < 0;
        }

        public void AddDay()
        {
            StartTime = StartTime.AddDays(1);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartTime;
            yield return EndTime;
        }
    }
}
