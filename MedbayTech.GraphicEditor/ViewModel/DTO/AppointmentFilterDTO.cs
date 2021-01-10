using GraphicEditor.ViewModel.Enums;
using System;
using System.Collections.Generic;

namespace GraphicEditor.ViewModel.DTO
{
    class AppointmentFilterDTO
    {
        public AppointmentFilterCriteria appointmentFilterCriteria { get; set; }
        public AppointmentSearchOrSchedule appointmentSearchOrSchedule { get; set; }
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public string DoctorId { get; set; }
        public int HospitalEquipmentId { get; set; }
        public int SpecializationId { get; set; }
        public Appointment appointment { get; set; }
        public List<Appointment> appointments { get; set; }

        public AppointmentFilterDTO() { }
    }
}
