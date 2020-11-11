// File:    IEmergencyRequestRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:26:11 AM
// Purpose: Definition of Interface IEmergencyRequestRepository

using Backend.Examinations.Model;
using System;
using System.Collections.Generic;

namespace Repository.ExaminationRepository
{
   public interface IEmergencyRequestRepository : IRepository<EmergencyRequest,int>
   {
        IEnumerable<EmergencyRequest> GetAllUnScheduled();
   }
}