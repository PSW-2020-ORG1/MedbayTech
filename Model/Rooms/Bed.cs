/***********************************************************************
 * Module:  RoomBed.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.ExaminationSurgery.RoomBed
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model.MedicalRecord;
using SimsProjekat.Repository;

namespace Model.Rooms
{
   public class Bed : IIdentifiable<int>
   {
        private int bedId;
        private bool currentlyFree;

        private Room room;
        private List<Occupation> occupations;

        public Bed(Room room)
        {
            Room = room;
            CurrentlyFree = true;
            Occupations = new List<Occupation>();
        }

        public int BedId { get { return bedId; } set { bedId = value; } }

        public bool CurrentlyFree { get { return currentlyFree; } set { currentlyFree = value; } }

        public Room Room { get { return room; } set { room = value; } }

        public List<Occupation> Occupations { get => occupations; set => occupations = value; }

        public int GetId()
        {
            return BedId;
        }

        public void SetId(int id)
        {
            BedId = id;
        }

        public void AddOccupation(Occupation occupation)
        {
            this.occupations.Add(occupation);
        }
    }
}