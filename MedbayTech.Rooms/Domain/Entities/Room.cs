/***********************************************************************
 * Module:  Room.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Schedule.Room
 ***********************************************************************/

using MedbayTech.Common.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Rooms.Domain
{
    public class Room : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RoomNumber { get;  set; }
        public RoomType RoomType { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get;  set; }
        [NotMapped]
        public virtual Department Department { get; set; }
        public virtual List<HospitalEquipment> HospitalEquipment { get;  set; }
        public string RoomLabel { get; set; }
        public string RoomUse { get; set; }
        public int BedsCapacity { get; set; }
        public int BedsFree { get; set; }
 
        public Room ()
        {
        }

        public Room (int id, int roomNumber, RoomType roomType, Department department)
        {
            Id = id;
            RoomNumber = roomNumber;
            RoomType = roomType;
            Department = department;
            DepartmentId = department.Id;
            HospitalEquipment = new List<HospitalEquipment>();
        }

        public int GetId ()
        {
            return Id;
        }

        public void SetId (int id)
        {
            Id = id;
        }

        public void UpdateRoom(Room room)
        {
            Id = room.Id;
            RoomNumber = room.RoomNumber;
            RoomType = room.RoomType;
            DepartmentId = room.DepartmentId;
            Department = room.Department;
            HospitalEquipment = room.HospitalEquipment;
            RoomLabel = room.RoomLabel;
            RoomUse = room.RoomUse;
            BedsCapacity = room.BedsCapacity;
            BedsFree = room.BedsFree;
        }
    }
}