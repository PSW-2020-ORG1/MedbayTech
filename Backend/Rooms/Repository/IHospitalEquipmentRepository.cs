// File:    IHospitalEquipmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:45:41 AM
// Purpose: Definition of Interface IHospitalEquipmentRepository

using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Repository.RoomRepository
{
   public interface IHospitalEquipmentRepository : IRepository<HospitalEquipment,int>
   {
        List<HospitalEquipment> GetEquipmentByRoomNumber(int roomNumber);

        List<HospitalEquipment> GetEquipmentByType(EquipmentType type);
   
   }
}