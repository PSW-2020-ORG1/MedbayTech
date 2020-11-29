using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class ReportSearchDTO
    {
        public String Doctor { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String type { get; set; }

        public ReportSearchDTO(string doctor, DateTime startDate, DateTime endDate, string type)
        {
            Doctor = doctor;
            this.startDate = startDate;
            this.endDate = endDate;
            this.type = type;
        }
    }
}
