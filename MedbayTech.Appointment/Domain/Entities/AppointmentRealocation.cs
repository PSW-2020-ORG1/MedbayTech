using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Appointment.Domain.Enums;
using MedbayTech.Common.Domain.Entities;

namespace MedbayTech.Appointment.Domain.Entities
{
    public class AppointmentRealocation : AppointmentForRoomManipulation
    {
        public int HospitalEquipmentId { get; set; }
        [NotMapped]
        public virtual HospitalEquipment HospitalEquipment { get; set; }
        public AppointmentRealocation() { }
    }
}
