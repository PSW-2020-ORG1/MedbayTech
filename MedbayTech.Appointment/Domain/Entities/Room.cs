using MedbayTech.Appointment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomLabel { get; set; }
        public RoomType RoomType { get; set; }

        public Room()
        {
        }

        public Room(int id, string roomLabel, RoomType roomType)
        {
            Id = id;
            RoomLabel = roomLabel;
            RoomType = roomType;
        }
    }
}
