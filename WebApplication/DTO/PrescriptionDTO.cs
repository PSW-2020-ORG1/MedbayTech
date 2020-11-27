using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PrescriptionDTO
    {
        public String Medication { get; set; }
        public int HourlyIntake { get; set; }
        public DateTime Date { get; set; }

        public PrescriptionDTO(string medication, int hourlyIntake, DateTime date)
        {
            Medication = medication;
            HourlyIntake = hourlyIntake;
            Date = date;
        }
    }
}
