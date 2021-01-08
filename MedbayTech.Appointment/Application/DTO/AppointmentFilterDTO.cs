using System;
using System.Collections.Generic;
using MedbayTech.Appointment.Application.Enums;
using MedbayTech.Appointment.Infrastructure.Services.AppointmentSearchOrSchedule;

namespace MedbayTech.Appointment.Application.DTO
{
    public class AppointmentFilterDTO
    {
        public AppointmentFilterCriteria AppointmentFilterCriteria { get; set; }
        public AppointmentSearchOrSchedule AppointmentSearchOrSchedule { get; set; }
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public string DoctorId { get; set; }
        public int HospitalEquipmentId { get; set; }
        public Domain.Entities.Appointment Appointment { get; set; }
        public List<Domain.Entities.Appointment> Appointments { get; set; }

        public AppointmentFilterDTO() {
           
        }
    }
}
