using MedbayTech.Appointment.Domain.Enums;
using MedbayTech.Common.Domain.Entities;
using MedbayTech.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Domain.Entities
{
    public class AppointmentForRoomManipulation : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        public virtual Period Period { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        public bool IsCanceled { get; set; }
        public int RoomId { get; set; }
        [NotMapped]
        public virtual Room Room { get; set; }
        public AppointmentForRoomManipulation() { }

        public bool isOccupied(Period p)
        {
            return DateTime.Compare(Period.StartTime, p.StartTime) == 0 && DateTime.Compare(Period.EndTime, p.EndTime) == 0;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
