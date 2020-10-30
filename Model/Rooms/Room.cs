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
   public class  Room : IIdentifiable<int>
   {
        private int roomID;
        private int roomNumber;
        private RoomType roomType;
        private Department department;
        private List<HospitalEquipment> hospitalEquipment;


        public int RoomID { get => roomID; set => roomID = value; }
        public int RoomNumber { get => roomNumber; set => roomNumber = value; }
        public  RoomType RoomType{ get => roomType; set => roomType= value; }
        public Department Department { get => department; set => department = value; }

        public List<HospitalEquipment> HospitalEquipment{ get => hospitalEquipment; set => hospitalEquipment = value; }

        public Room() { }

        public Room(int roomNumber, RoomType roomType, Department department,List<HospitalEquipment> hospitalEquipment)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            Department = department;
            HospitalEquipment = hospitalEquipment;
        }

        public Room(int id)
        {
            RoomID = id;
        }

        public int GetId()
        {
            return RoomID;
        }

        public void SetId(int id)
        {
            RoomID = id;
        }
    }
}