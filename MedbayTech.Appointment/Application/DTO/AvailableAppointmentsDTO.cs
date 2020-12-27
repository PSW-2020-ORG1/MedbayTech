using System;

namespace Application.DTO
{
    public class AvailableAppointmentsDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string DoctorFullName { get; set; }

        public string DoctorId { get; set; }
        public AvailableAppointmentsDTO() { }
    }
}
