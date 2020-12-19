// File:    IBedRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:48:49 AM
// Purpose: Definition of Interface IBedRepository

using Model.Rooms;
using System.Collections.Generic;

namespace Repository.RoomRepository
{
   public interface IBedRepository : IRepository<Bed,int>
   {
        List<Bed> GetBedsByRoomNumber(int roomNumber);
   
   }
}