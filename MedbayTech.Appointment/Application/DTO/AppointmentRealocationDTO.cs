
using MedbayTech.Appointment.Application.Enums;
using MedbayTech.Appointment.Domain.Entities;
using System;

namespace MedbayTech.Appointment.Application.DTO
{
    public class AppointmentRealocationDTO
    {
        public AppointmentRealocationSearchOrSchedule appointmentRealocationSearchOrSchedule { get; set; }
        public DateTime StartInterval { get; set; }
        public DateTime EndInterval { get; set; }
        public int RoomId { get; set; }
        public int FromRoomId { get; set; }
        public int ToRoomId { get; set; }
        public int EquipmentTypeId { get; set; }
        public int HospitalEquipmentId { get; set; }
        public AppointmentRealocation appointmentRealocation { get; set; }
    }
}
