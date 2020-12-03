// File:    ISurveyRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:15:56 AM
// Purpose: Definition of Interface ISurveyRepository

using Model.Users;
using System;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public interface ISurveyRepository : ICreate<Survey>, IGetAll<Survey>
   {
        public int GetLastId();
    }
}