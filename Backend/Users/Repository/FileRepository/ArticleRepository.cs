/***********************************************************************
 * Module:  ArticleRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.ArticleRepository
 ***********************************************************************/

using Model.Users;
using System;
using System.Collections.Generic;
using Repository.UserRepository;
using System.Linq;
using Repository;
using SimsProjekat.SIMS.Exceptions;
using Backend.General.Model;

namespace Backend.Users.Repository.MySqlRepository
{
   public class ArticleRepository : JSONRepository<Article, int>,
        IArticleRepository, ObjectComplete<Article>
    {
        public IUserRepository userRepository;
        public Stream<Article> stream;
        private const string NOT_FOUND = "Article with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Article with ID number {0} already exists!";

        public ArticleRepository(IUserRepository userRepository, Stream<Article> stream) : base(stream, "Article")
        {
            this.stream = stream;
            this.userRepository = userRepository;
        }

        public new Article Create(Article entity)
        {
            SetMissingValues(entity);
            entity.Id = GetNextID();
            return base.Create(entity);
        }

        public new IEnumerable<Article> GetAll()
        {
            var allArticles = base.GetAll().ToList();
            for (int i = 0; i < allArticles.Count; i++)
            {
                CompleteObject(allArticles[i]);
            }
            return allArticles;
        }

        public IEnumerable<Article> GetArticlesWroteByDoctor(Doctor doctor)
        {
            var articlesByDcotor = stream.GetAll().Where(article => article.Doctor.Username.Equals(doctor.Username)).ToList();
            foreach (Article article in articlesByDcotor)
            {
                CompleteObject(article);
            }
            return articlesByDcotor;
        }

        public new Article GetObject(int id)
        {
            var article = base.GetObject(id);
            CompleteObject(article);
            return article;
        }

        public new Article Update(Article entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }
        private int GetNextID() => stream.GetAll().ToList().Count + 1;
        
        public void CompleteObject(Article article)
        {
            article.Doctor = (Doctor) userRepository.GetObject(article.Doctor.Username);
        }
        
        public void SetMissingValues(Article entity)
        {
            entity.Doctor = new Doctor();
        }

    }
}