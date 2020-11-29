using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PrescriptionSearchDTO
    {
        public String Medicine { get; set; }
        public int HourlyIntake { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PrescriptionSearchDTO(string medication, int hourlyIntake, DateTime date)
        {
            Medicine = medication;
            HourlyIntake = hourlyIntake;
            StartDate = date;
            EndDate = date;
        }
    }
}
