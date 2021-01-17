﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Appointment.Domain.Enums;
using MedbayTech.Common.Domain.Entities;

namespace MedbayTech.Appointment.Domain.Entities
{
    public class AppointmentRealocation : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public AppointmentRealocationType AppointmentRealocationType { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        public bool IsCanceled { get; set; }
        public string Description { get; set; }
        public int RoomId { get; set; }
        [NotMapped]
        public virtual Room Room { get; set; }
        public RoomType RoomOneType { get; set; }
        public string RoomOneUse { get; set; }
        public string RoomOneLabel { get; set; }
        public RoomType RoomTwoType { get; set; }
        public string RoomTwoUse { get; set; }
        public string RoomTwoLabel { get; set; }
        public int HospitalEquipmentId { get; set; }
        [NotMapped]
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
