using Backend.Rooms.Service;
using Model.Rooms;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimsProjekat.Service.RoomService
{
    public class EquipmentTypeService : IEquipmentTypeService
    {
        public EquipmentTypeRepository equipmentTypeRepository;
        public IEquipmentTypeRepository _equipmentTypeRepository;

        public EquipmentTypeService(IEquipmentTypeRepository equipmentTypeRepository)
        {
            _equipmentTypeRepository = equipmentTypeRepository;
        }
        public EquipmentTypeService(EquipmentTypeRepository equipmentTypeRepository)
        {
            this.equipmentTypeRepository = equipmentTypeRepository;
        }

        public EquipmentType AddNewType(EquipmentType type) => equipmentTypeRepository.Create(type);

        public IEnumerable<EquipmentType> GetAllTypes() => equipmentTypeRepository.GetAll();

        public List<EquipmentType> GetAllEquipment()
        {
            return _equipmentTypeRepository.GetAll().ToList();
        }

    }
}
