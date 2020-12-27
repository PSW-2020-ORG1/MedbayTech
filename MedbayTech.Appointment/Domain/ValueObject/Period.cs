using System;

namespace Domain.ValueObject
{
    public class Period
    {
        public int Id { get; set; }
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
    }
}
