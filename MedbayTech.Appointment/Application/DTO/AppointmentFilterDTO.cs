using MedbayTech.Appointment.Application.Enums;
using System;
using System.Collections.Generic;

namespace MedbayTech.Appointment.Application.DTO
{
    public class AppointmentFilterDTO
    {
        public AppointmentFilterCriteria AppointmentFilterCriteria { get; set; }
        public AppointmentSearchOrSchedule AppointmentSearchOrSchedule { get; set; }
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public string DoctorId { get; set; }
        public int SpecializationId { get; set; }
        public int HospitalEquipmentId { get; set; }
        public Domain.Entities.Appointment Appointment { get; set; }
        public List<Domain.Entities.Appointment> Appointments { get; set; }

        public AppointmentFilterDTO() {
           
        }
    }
}
