using System;

namespace Application.DTO
{
    public class SearchAppointmentsDTO
    {
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public string DoctorId { get; set; }
        public int Priority { get; set; }
        public string SpecializationName { get; set; }

        public SearchAppointmentsDTO() { }

    }
}
