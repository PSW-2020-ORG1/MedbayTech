// File:    IEquipmentTypeRepository.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 3:21:59 AM
// Purpose: Definition of Interface IEquipmentTypeRepository

using Model.Rooms;
using System;

namespace Repository.RoomRepository
{
   public interface IEquipmentTypeRepository : IRepository<EquipmentType, int>
   {

   }
}