using MedbayTech.Appointment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Domain.Entities
{
    public class AppointmentRenovation : AppointmentForRoomManipulation
    {
        public AppointmentRealocationType AppointmentRealocationType { get; set; }
        public string Description { get; set; }
        public RoomType RoomOneType { get; set; }
        public string RoomOneUse { get; set; }
        public string RoomOneLabel { get; set; }
        public RoomType RoomTwoType { get; set; }
        public string RoomTwoUse { get; set; }
        public string RoomTwoLabel { get; set; }
        public AppointmentRenovation() { }
    }
}
