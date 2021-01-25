using GraphicEditor.ViewModel;
using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.GraphicEditor.ViewModel.Enums;
using MedbayTech.Rooms.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.GraphicEditor.ViewModel
{
    public class AppointmentRenovation
    {
        public int Id { get; set; }
        public AppointmentRealocationType AppointmentRealocationType { get; set; }
        public Period Period { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        public bool IsCanceled { get; set; }
        public string Description { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public RoomType RoomOneType { get; set; }
        public string RoomOneUse { get; set; }
        public string RoomOneLabel { get; set; }
        public RoomType RoomTwoType { get; set; }
        public string RoomTwoUse { get; set; }
        public string RoomTwoLabel { get; set; }
        List<HospitalEquipment> HospitalEquipments { get; set; }
        public AppointmentRenovation() { }
    }
}
