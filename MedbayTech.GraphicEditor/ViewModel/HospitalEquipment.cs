
namespace GraphicEditor.ViewModel
{
    public class HospitalEquipment
    {
        public int Id { get; set; }
        public int QuantityInRoom { get; set; }
        public int QuantityInStorage { get; set; }
        public virtual Room Room { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }

        public HospitalEquipment()
        {
        }

        public HospitalEquipment(int id, int quantityInRoom, int quantityInStorage, Room room, EquipmentType equipmentType)
        {
            Id = id;
            QuantityInRoom = quantityInRoom;
            QuantityInStorage = quantityInStorage;
            Room = room;
            EquipmentType = equipmentType;
        }
    }
}
