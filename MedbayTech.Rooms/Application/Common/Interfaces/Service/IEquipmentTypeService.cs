﻿
using MedbayTech.Rooms.Domain;
using System.Collections.Generic;


namespace MedbayTech.Rooms.Application.Common.Service
{
    public interface IEquipmentTypeService
    {
        List<EquipmentType> GetAllEquipment();
        List<EquipmentType> GetAllTypes();
        EquipmentType AddNewType(EquipmentType type);

    }
}
