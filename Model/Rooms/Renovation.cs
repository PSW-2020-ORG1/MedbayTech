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
        private int renovationId;
        private DateTime startDate;
        private DateTime endDate;
        private bool moveEquipment = false;
        private Room room;

        public int RenovationId { get => renovationId; set => renovationId = value; }
        public DateTime StartDate{ get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public bool MoveEquipment { get => moveEquipment; set => moveEquipment=value; }
        public Room Room { get => room; set => room = value; }

        public Renovation() { }
        public Renovation(int id) 
        {
            RenovationId = id;
        }

        public Renovation(DateTime startDate, DateTime endDate, bool moveEquipment, Room room)
        {
            Room = room;
            StartDate = startDate;
            EndDate = endDate;
            MoveEquipment = moveEquipment;
        }

        public int GetId()
        {
            return RenovationId;
        }

        public void SetId(int id)
        {
            RenovationId = id;
        }
    }
}