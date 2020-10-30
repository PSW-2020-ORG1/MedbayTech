using Model.Rooms;
using SimsProjekat.Service.RoomService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Controller.RoomController
{
   public class EquipmentTypeController
    {
        public EquipmentTypeController(EquipmentTypeService equipmentTypeService)
        {
            this.equipmentTypeService = equipmentTypeService;
        }

        public EquipmentType AddNewType(EquipmentType type) => equipmentTypeService.AddNewType(type);
        public IEnumerable<EquipmentType> GetAllTypes() => equipmentTypeService.GetAllTypes();

        public EquipmentTypeService equipmentTypeService;
    }
}
