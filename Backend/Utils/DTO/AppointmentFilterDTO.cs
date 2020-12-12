using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    public class AppointmentFilterDTO
    {
        public int operation { get; set; }
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public string DoctorId { get; set; }
        public int HospitalEquipmentId { get; set; }
        public Appointment appointment { get; set; }
        public List<Appointment> appointments { get; set; }

        public AppointmentFilterDTO() { }
    }
}
