using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    public class SearchAppointmentsDTO
    {
        public int operation { get; set; }
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public string DoctorId { get; set; }
        public int HospitalEquipmentId { get; set; }
        public Appointment appointment { get; set; }
        public int Priority { get; set; }

        public SearchAppointmentsDTO() { }

    }
}
