// File:    IArticleRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:16:58 AM
// Purpose: Definition of Interface IArticleRepository

using Model.Users;
using System.Collections.Generic;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public interface IArticleRepository : IRepository<Article,int>
   {
        List<Article> GetArticlesWroteByDoctor(Doctor doctor);
   
   }
}