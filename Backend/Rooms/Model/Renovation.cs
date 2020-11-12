// File:    Renovation.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 9:12:45 PM
// Purpose: Definition of Class Renovation

using System;
using Backend.Utils;
using SimsProjekat.Repository;

namespace Model.Rooms
{
    public class Renovation : IIdentifiable<int>
    {
        public int Id { get; set; }
        public Period Period { get; set; }
        public bool MoveEquipment { get; protected set; }
        public virtual Room Room { get; set; }
        public int RoomId { get; protected set; }

        public Renovation ()
        {
        }

        public Renovation (int id, Period period, bool moveEquipment, Room room)
        {
            Id = id;
            Room = room;
            RoomId = room.Id;
            Period = period;
            MoveEquipment = moveEquipment;
        }

        public int GetId ()
        {
            return Id;
        }

        public void SetId (int id)
        {
            Id = id;
        }
    }
}