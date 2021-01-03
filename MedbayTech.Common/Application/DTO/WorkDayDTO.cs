using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Common.Application.DTO
{
    public class WorkDayDTO
    {
        public string DoctorId { get; set; }
        public DateTime Date { get; set; }

        public WorkDayDTO()
        {
        }

        public WorkDayDTO(string doctorId, DateTime date)
        {
            DoctorId = doctorId;
            Date = date;
        }
    }
}
