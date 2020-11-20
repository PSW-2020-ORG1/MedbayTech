// File:    IFeedbackRepository.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 4:15:45 AM
// Purpose: Definition of Interface IFeedbackRepository

using Model.Users;
using System;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public interface IFeedbackRepository : ICreate<Feedback>, IGetAll<Feedback> 
   {

   }
}