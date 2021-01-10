// File:    IRoomRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:45:42 AM
// Purpose: Definition of Interface IRoomRepository


using MedbayTech.Common.Repository;
using MedbayTech.Rooms.Domain;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Persistance
{
   public interface IRoomRepository : IRepository<Room, int>
   {
   
   }
}