// File:    Renovation.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 9:12:45 PM
// Purpose: Definition of Class Renovation

using MedbayTech.Common.Domain.Entities;
using MedbayTech.Common.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedbayTech.Rooms.Domain
{
    public class Renovation : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        public Period Period { get; set; }
        public bool MoveEquipment { get; protected set; }
        [ForeignKey("Room")]
        public int RoomId { get; protected set; }
        public virtual Room Room { get; set; }

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