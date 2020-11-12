/***********************************************************************
 * Module:  Room.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Schedule.Room
 ***********************************************************************/

using Model.Users;
using SimsProjekat.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Model.Rooms
{
    public class Room : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public int RoomNumber { get; protected set; }
        public RoomType RoomType { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; protected set; }
        public virtual Department Department { get; set; }
        public virtual List<HospitalEquipment> HospitalEquipment { get; protected set; }

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

    }
}