using GraphicEditor.ViewModel;
using MedbayTech.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.GraphicEditor.ViewModel
{
    public class AppointmentForRoomManipulation
    {
        public int Id { get; set; }
        public Period Period { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        public bool IsCanceled { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public AppointmentForRoomManipulation () { }
    }
}
