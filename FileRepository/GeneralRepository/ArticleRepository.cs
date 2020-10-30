/***********************************************************************
 * Module:  ArticleRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.ArticleRepository
 ***********************************************************************/

using Model.Users;
using Repository.ReportRepository;
using System;
using System.Collections.Generic;
using Repository.UserRepository;
using System.Linq;
using SimsProjekat.SIMS.Exceptions;
using SimsProjekat.Repository;

namespace Repository.GeneralRepository
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
            var articlesByDcotor = stream.GetAll().Where(article => article.author.Username.Equals(doctor.Username)).ToList();
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
            article.Author = (Doctor) userRepository.GetObject(article.Author.Username);
        }
        
        public void SetMissingValues(Article entity)
        {
            entity.Author = new Doctor(entity.Author.Username);
        }

    }
}