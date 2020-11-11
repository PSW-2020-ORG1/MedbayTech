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
        public int Id { get; set; }
        public bool CurrentlyFree { get; set; }

        public virtual Room Room { get; set; }
        public int RoomId { get; set; }
        public virtual List<Occupation> Occupations { get; set; }

        public Bed ( Room room )
        {
            Room = room;
            CurrentlyFree = true;
            Occupations = new List<Occupation>();
        }

        public Bed ( )
        {
        }

        public void AddOccupation ( Occupation occupation )
        {
            this.Occupations.Add(occupation);
        }

        public int GetId ( )
        {
            return Id;
        }

        public void SetId ( int id )
        {
            this.Id = id;
        }
    }
}