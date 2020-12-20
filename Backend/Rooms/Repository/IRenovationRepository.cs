// File:    IRenovationRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:46:50 AM
// Purpose: Definition of Interface IRenovationRepository

using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Repository.RoomRepository
{
   public interface IRenovationRepository : IRepository<Renovation,int>
   {
        List<Renovation> GetAllFromDate(DateTime date);
   
   }
}