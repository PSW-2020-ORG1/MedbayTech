using GraphicEditor.ViewModel;
using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.GraphicEditor.ViewModel.Enums;
using MedbayTech.Rooms.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.GraphicEditor.ViewModel
{
    public class AppointmentRealocation
    {
        
        public int Id { get; set; }
        public Period Period { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        public bool IsCanceled { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int HospitalEquipmentId { get; set; }
        public virtual HospitalEquipment HospitalEquipment { get; set; }
        public AppointmentRealocation() { }
    }
}
