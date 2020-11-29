using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class ReportDTO
    {
        public String Doctor { get; set; }
        public DateTime Date { get; set; }
        public String Type { get; set; }

        public ReportDTO(string doctor, DateTime date, string type)
        {
            Doctor = doctor;
            Date = date;
            Type = type;
        }
    }
}
