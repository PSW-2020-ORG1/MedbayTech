/***********************************************************************
 * Module:  RoomBed.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.ExaminationSurgery.RoomBed
 ***********************************************************************/

using Backend.General.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Rooms
{
    public class Bed : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public bool CurrentlyFree { get; protected set; }

        [ForeignKey("Room")]
        public int RoomId { get; protected set; }
        public virtual Room Room { get;  set; }

        // TODO(Jovan): Needs DB storage?
        [NotMapped]
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