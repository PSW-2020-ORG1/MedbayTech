using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Appointment.Application.Enums;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Appointment.Infrastructure.Services.AppointmentSearchOrSchedule;

namespace MedbayTech.Appointment.Application.DTO
{
    public class AppointmentFilterDTO
    {
        public AppointmentFilterCriteria appointmentFilterCriteria { get; set; }
        public AppointmentSearchOrSchedule appointmentSearchOrSchedule { get; set; }
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public string DoctorId { get; set; }
        public int HospitalEquipmentId { get; set; }
        public MedbayTech.Appointment.Domain.Entities.Appointment appointment { get; set; }
        public List<MedbayTech.Appointment.Domain.Entities.Appointment> appointments { get; set; }

        public AppointmentFilterDTO() { }
    }
}
