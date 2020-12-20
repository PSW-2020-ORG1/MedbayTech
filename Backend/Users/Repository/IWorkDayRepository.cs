// File:    IWorkDayRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:57:47 AM
// Purpose: Definition of Interface IWorkDayRepository

using Model.Users;
using System.Collections.Generic;

namespace Repository.UserRepository
{
   public interface IWorkDayRepository : IRepository<WorkDay,int>
   {
        List<WorkDay> GetWorkTimeForEmployee(Model.Users.Employee employee);
   
   }
}