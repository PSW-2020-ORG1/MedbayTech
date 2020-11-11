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

namespace Model.Rooms
{
    public class Room : IIdentifiable<int>
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }
        public virtual List<HospitalEquipment> HospitalEquipment { get; set; }

        public Room ( )
        {
        }

        public Room ( int roomNumber, RoomType roomType, Department department, List<HospitalEquipment> hospitalEquipment )
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            Department = department;
            HospitalEquipment = hospitalEquipment;
        }

        public Room ( int id )
        {
            Id = id;
        }

        public int GetId ( )
        {
            return Id;
        }

        public void SetId ( int id )
        {
            Id = id;
        }
    }
}