using Backend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public string Medicine { get; set; }
        public Boolean AndOr { get; set; }
        public int HourlyIntake { get; set; }
        
        public PrescriptionDTO(int id, string medicine, int hour)
        {
            this.Id = id;
            this.Medicine = medicine;
            this.HourlyIntake = hour;
           
        }
    }
}
