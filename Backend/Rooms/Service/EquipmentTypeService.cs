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
        public IEquipmentTypeRepository _equipmentTypeRepository;

        public EquipmentTypeService(IEquipmentTypeRepository equipmentTypeRepository)
        {
            _equipmentTypeRepository = equipmentTypeRepository;
        }

        public EquipmentType AddNewType(EquipmentType type) => _equipmentTypeRepository.Create(type);

        public List<EquipmentType> GetAllTypes() => _equipmentTypeRepository.GetAll();

        public List<EquipmentType> GetAllEquipment()
        {
            return _equipmentTypeRepository.GetAll().ToList();
        }

    }
}
