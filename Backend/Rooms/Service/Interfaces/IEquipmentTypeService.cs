using Model.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Rooms.Service
{
    public interface IEquipmentTypeService
    {
        List<EquipmentType> GetAllEquipment();
        List<EquipmentType> GetAllTypes();
        EquipmentType AddNewType(EquipmentType type);

    }
}
