// File:    IQuestionRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:21:20 AM
// Purpose: Definition of Interface IQuestionRepository

using Model.Users;
using System;
using System.Collections.Generic;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public interface IQuestionRepository : IRepository<Question,int>
   {
        IEnumerable<Question> GetFAQ();
   }
}