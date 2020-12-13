using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    public class SearchAppointmentsDTO
    {
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public string DoctorId { get; set; }
        public int Priority { get; set; }
        public int SpecializationId { get; set; }

        public SearchAppointmentsDTO() { }

    }
}
