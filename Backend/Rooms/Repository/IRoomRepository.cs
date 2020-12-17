// File:    IRoomRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:45:42 AM
// Purpose: Definition of Interface IRoomRepository

using Model.Rooms;
using System;

namespace Repository.RoomRepository
{
   public interface IRoomRepository : IRepository<Room, int>
   {
   
   }
}