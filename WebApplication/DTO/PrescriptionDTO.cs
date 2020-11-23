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
        public int HourlyIntake { get; set; }
        public Period  ReservationPeriod { get; set; }

        public PrescriptionDTO(int id, string medicine, int hour, Period period)
        {
            this.Id = id;
            this.Medicine = medicine;
            this.HourlyIntake = hour;
            this.ReservationPeriod = period;
        }
    }
}
