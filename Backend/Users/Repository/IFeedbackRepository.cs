// File:    IFeedbackRepository.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 4:15:45 AM
// Purpose: Definition of Interface IFeedbackRepository

using Model.Users;
using System;
using Repository;
using System.Collections.Generic;

namespace Backend.Users.Repository.MySqlRepository
{
   public interface IFeedbackRepository : ICreate<Feedback>, IGetAll<Feedback>
   {
        public IEnumerable<Feedback> GetAllApprovedFeedback();
        public bool UpdateStatus(int feedbackId, bool status);
        public int GetLastId();

    }
}