// File:    IEquipmentTypeRepository.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 3:21:59 AM
// Purpose: Definition of Interface IEquipmentTypeRepository


using MedbayTech.Common.Repository;
using MedbayTech.Rooms.Domain;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Persistance
{
   public interface IEquipmentTypeRepository : IRepository<EquipmentType, int>
   {

   }
}