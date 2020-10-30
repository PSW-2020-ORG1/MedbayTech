// File:    IArticleRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:16:58 AM
// Purpose: Definition of Interface IArticleRepository

using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository.GeneralRepository
{
   public interface IArticleRepository : IRepository<Article,int>
   {
      IEnumerable<Article> GetArticlesWroteByDoctor(Model.Users.Doctor doctor);
   
   }
}