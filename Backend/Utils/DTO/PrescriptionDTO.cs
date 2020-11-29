using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PrescriptionDTO
    {
        public String Medicine { get; set; }
        public int HourlyIntake { get; set; }
        public DateTime Date { get; set; }

        public PrescriptionDTO(string medication, int hourlyIntake, DateTime date)
        {
            Medicine = medication;
            HourlyIntake = hourlyIntake;
            Date = date;
        }
    }
}
