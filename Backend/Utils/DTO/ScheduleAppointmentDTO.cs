using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    public class ScheduleAppointmentDTO
    {
        public string DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PatientId { get; set; }
        public int SpecializationId { get; set; }
        public ScheduleAppointmentDTO() {}

    }
}
