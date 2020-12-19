// File:    IVacationRequestRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 1:08:28 AM
// Purpose: Definition of Interface IVacationRequestRepository

using Model.Users;
using System.Collections.Generic;

namespace Repository.UserRepository
{
   public interface IVacationRequestRepository : IRepository<VacationRequest,int>
   {
        List<VacationRequest> GetAllUnapproved();
   
   }
}