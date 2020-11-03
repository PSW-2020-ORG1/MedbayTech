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
        public int Id { get; set; }
        public int QuantityInRoom { get; set; }
        public int QuantityInStorage { get; set; }
        public int RoomNumberIn { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }
        public int EquipmentTypeId { get; set; }

        public HospitalEquipment (int roomNumberIn, int quantityInRoom, int quantityinStorage, EquipmentType et )
        {
            QuantityInRoom = quantityInRoom;
            QuantityInStorage = quantityinStorage;
            RoomNumberIn = roomNumberIn;
            EquipmentType = et;
            
        }

        public HospitalEquipment ( )
        {
        }

        public int GetId ( )
        {
            return Id;
        }

        public void SetId ( int id )
        {
            this.Id = id;
        }
    }
}