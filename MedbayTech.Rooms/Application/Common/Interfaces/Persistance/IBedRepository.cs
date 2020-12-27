// File:    IBedRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:48:49 AM
// Purpose: Definition of Interface IBedRepository



using MedbayTech.Common.Repository;
using MedbayTech.Rooms.Domain;
using System.Collections.Generic;


namespace MedbayTech.Rooms.Application.Common.Interfaces.Persistance
{
   public interface IBedRepository : IRepository<Bed,int>
   {
        List<Bed> GetBedsByRoomNumber(int roomNumber);
   
   }
}