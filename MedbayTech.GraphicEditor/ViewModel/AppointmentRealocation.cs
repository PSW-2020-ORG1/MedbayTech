﻿using GraphicEditor.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.GraphicEditor.ViewModel
{
    public class AppointmentRealocation
    {
        
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }     
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int HospitalEquipmentId { get; set; }
        public virtual HospitalEquipment HospitalEquipment { get; set; }
        public AppointmentRealocation() { }

        public bool isOccupied(DateTime start, DateTime end)
        {
            return DateTime.Compare(Start, start) == 0 && DateTime.Compare(End, end) == 0;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

    }
}
