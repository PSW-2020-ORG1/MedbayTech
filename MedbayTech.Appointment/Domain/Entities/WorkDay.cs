using MedbayTech.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Domain.Entities
{
    public class WorkDay
    {
        public string EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Doctor Doctor { get; set; }

        public WorkDay()
        {
        }

        public WorkDay(string employeeId, DateTime date, int startTime, int endTime, Doctor doctor)
        {
            EmployeeId = employeeId;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Doctor = doctor;
        }
    }
}
