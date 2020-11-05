// File:    Renovation.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 9:12:45 PM
// Purpose: Definition of Class Renovation

using System;
using SimsProjekat.Repository;

namespace Model.Rooms
{
    public class Renovation : IIdentifiable<int>
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool MoveEquipment { get; set; }
        public virtual Room Room { get; set; }
        public int RoomId { get; set; }

        public Renovation ( )
        {
        }

        public Renovation ( int id )
        {
            Id = id;
        }

        public Renovation ( DateTime startDate, DateTime endDate, bool moveEquipment, Room room )
        {
            Room = room;
            StartDate = startDate;
            EndDate = endDate;
            MoveEquipment = moveEquipment;
        }

        public int GetId ( )
        {
            return Id;
        }

        public void SetId ( int id )
        {
            Id = id;
        }
    }
}