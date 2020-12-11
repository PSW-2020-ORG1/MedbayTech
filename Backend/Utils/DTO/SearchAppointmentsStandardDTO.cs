using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    public class SearchAppointmentsStandardDTO
    {
        public string DoctorId { get; set; }
        public DateTime Date { get; set; }

        public SearchAppointmentsStandardDTO() { }
    }
}
