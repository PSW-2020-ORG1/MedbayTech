// File:    IHospitalEquipmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:45:41 AM
// Purpose: Definition of Interface IHospitalEquipmentRepository

using MedbayTech.Common.Repository;
using MedbayTech.Rooms.Domain;
using System.Collections.Generic;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Persistance
{
   public interface IHospitalEquipmentRepository : IRepository<HospitalEquipment,int>
   {
        List<HospitalEquipment> GetEquipmentByRoomNumber(int roomNumber);

        List<HospitalEquipment> GetEquipmentByType(EquipmentType type);
   
   }
}