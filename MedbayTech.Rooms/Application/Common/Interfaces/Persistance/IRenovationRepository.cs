// File:    IRenovationRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:46:50 AM
// Purpose: Definition of Interface IRenovationRepository

using MedbayTech.Common.Repository;
using MedbayTech.Rooms.Domain;
using System;
using System.Collections.Generic;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Persistance
{
   public interface IRenovationRepository : IRepository<Renovation,int>
   {
        List<Renovation> GetAllFromDate(DateTime date);
   
   }
}