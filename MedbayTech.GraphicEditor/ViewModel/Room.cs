using MedbayTech.Rooms.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.ViewModel
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<HospitalEquipment> HospitalEquipment { get; set; }
        public string RoomLabel { get; set; }
        public string RoomUse { get; set; }
        public int BedsCapacity { get; set; }
        public int BedsFree { get; set; }

        public Room()
        {
        }

        public Room(int id, int roomNumber, RoomType roomType, Department department, List<HospitalEquipment> hospitalEquipment, string roomLabel, string roomUse, int bedsCapacity, int bedsFree)
        {
            Id = id;
            RoomNumber = roomNumber;
            RoomType = roomType;
            Department = department;
            HospitalEquipment = hospitalEquipment;
            RoomLabel = roomLabel;
            RoomUse = roomUse;
            BedsCapacity = bedsCapacity;
            BedsFree = bedsFree;
        }
    }
}
