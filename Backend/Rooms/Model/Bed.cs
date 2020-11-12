/***********************************************************************
 * Module:  RoomBed.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.ExaminationSurgery.RoomBed
 ***********************************************************************/

using SimsProjekat.Repository;
using System.Collections.Generic;

namespace Model.Rooms
{
    public class Bed : IIdentifiable<int>
    {
        public int Id { get; set; }
        public bool CurrentlyFree { get; protected set; }

        public virtual Room Room { get;  set; }
        public int RoomId { get; protected set; }
        public virtual List<Occupation> Occupations { get;  set; }

        public Bed (Room room)
        {
            Room = room;
            RoomId = room.Id;
            CurrentlyFree = true;
            Occupations = new List<Occupation>();
        }

        public Bed ()
        {
        }

        public void AddOccupation (Occupation occupation)
        {
            this.Occupations.Add(occupation);
        }

        public int GetId ()
        {
            return Id;
        }

        public void SetId (int id)
        {
            this.Id = id;
        }
    }
}