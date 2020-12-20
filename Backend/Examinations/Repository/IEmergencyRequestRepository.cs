// File:    IEmergencyRequestRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:26:11 AM
// Purpose: Definition of Interface IEmergencyRequestRepository

using Backend.Examinations.Model;
using System.Collections.Generic;
using Repository;

namespace Backend.Examinations.Repository
{
   public interface IEmergencyRequestRepository : IRepository<EmergencyRequest,int>
   {
        List<EmergencyRequest> GetAllUnScheduled();
   }
}