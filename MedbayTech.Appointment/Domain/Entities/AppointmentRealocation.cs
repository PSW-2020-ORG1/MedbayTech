using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Entities;

namespace MedbayTech.Appointment.Domain.Entities
{
    public class AppointmentRealocation : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        [ForeignKey("HospitalEquipment")]
        public int HospitalEquipmentId { get; set; }
        public virtual HospitalEquipment HospitalEquipment { get; set; }
        public AppointmentRealocation() { }

        public bool isOccupied(DateTime start, DateTime end)
        {
            return DateTime.Compare(Start, start) == 0 && DateTime.Compare(End, end) == 0;
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
