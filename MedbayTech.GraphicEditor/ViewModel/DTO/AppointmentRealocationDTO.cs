using MedbayTech.GraphicEditor.ViewModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.GraphicEditor.ViewModel.DTO
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
        public AppointmentRenovation appointmentRenovation { get; set; }
        public AppointmentForRoomManipulation appointmentForRoomManipulation { get; set; }
    }
}
