using Backend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PrescriptionAdvancedDTO
    {
        public string Medication { get; set; }
        public string AndOr { get; set; }
        public string HourlyIntake { get; set; }
        
        public PrescriptionAdvancedDTO(string medication, string hour, string operators)
        {
            this.Medication = medication;
            this.HourlyIntake = hour;
            this.AndOr = operators;
           
           
        }
    }
}
