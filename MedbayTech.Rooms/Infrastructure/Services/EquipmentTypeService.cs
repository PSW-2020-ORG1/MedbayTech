
using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Application.Common.Interfaces.Service;
using MedbayTech.Rooms.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Rooms.Infrastructure.Services
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
