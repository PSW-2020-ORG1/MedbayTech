/***********************************************************************
 * Module:  HospitalEquipment.cs
 * Author:  ThinkPad
 * Purpose: Definition of the Class HealthCorporation.2Manager.HospitalEquipment
 ***********************************************************************/

using MedbayTech.Common.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedbayTech.Rooms.Domain
{
    public class HospitalEquipment : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int QuantityInRoom { get; set; }
        public int QuantityInStorage { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        [NotMapped]
        public virtual Room Room { get; set; }
        [ForeignKey("EquipmentType")]
        public int EquipmentTypeId { get; set; }
        [NotMapped]
        public virtual EquipmentType EquipmentType { get; set; }


        public HospitalEquipment(int id, int quantityInRoom, int quantityinStorage, Room room, EquipmentType et)
        {
            QuantityInRoom = quantityInRoom;
            QuantityInStorage = quantityinStorage;
            Room = room;
            RoomId = Room.Id;
            EquipmentType = et;
            EquipmentTypeId = et.Id;
        }

        public HospitalEquipment()
        {
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }
        public void UpdateHospitalEquipment(HospitalEquipment hospitalEquipment)
        {
            Id = hospitalEquipment.Id;
            QuantityInRoom = hospitalEquipment.QuantityInRoom;
            QuantityInStorage = hospitalEquipment.QuantityInStorage;
            RoomId = hospitalEquipment.RoomId;
            Room = hospitalEquipment.Room;
            EquipmentTypeId = hospitalEquipment.EquipmentTypeId;
            EquipmentType = hospitalEquipment.EquipmentType;
        }
    }
}