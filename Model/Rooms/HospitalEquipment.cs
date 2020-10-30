/***********************************************************************
 * Module:  HospitalEquipment.cs
 * Author:  ThinkPad
 * Purpose: Definition of the Class HealthCorporation.2Manager.HospitalEquipment
 ***********************************************************************/

using System;
using SimsProjekat.Repository;

namespace Model.Rooms
{
    public class HospitalEquipment : IIdentifiable<int>
    {
        private int id;
        private int quantityInRoom;
        private int quantityInStorage;
        private int roomNumberIn;

        private EquipmentType equipmentType;
     //   private Room room;

        public int HospitalEquipmentID { get => id; set => id = value; }
        public int QuantityInRoom { get => quantityInRoom; set => quantityInRoom = value; }
        public int QuantityInStorage { get => quantityInStorage; set => quantityInStorage= value; }
    //    public int RoomNumberIn { get => roomNumberIn; set => roomNumberIn = value; }
        public EquipmentType EquipmentType { get => equipmentType; set => equipmentType= value; }
     //   public Room Room { get => room; set => room = value; }

        public HospitalEquipment(int quantityInRoom, int quantityinStorage,  EquipmentType et)
        {
            QuantityInRoom = quantityInRoom;
            QuantityInStorage = quantityInStorage;
      //      RoomNumberIn = roomNumberIn;
            EquipmentType = et;
        //    Room = room;
        }

        public int GetId()
        {
            return HospitalEquipmentID;
        }

        public void SetId(int id)
        {
            HospitalEquipmentID = id;
        }
    }
}