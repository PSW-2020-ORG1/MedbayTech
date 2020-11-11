/***********************************************************************
 * Module:  BlogService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.BlogService
 ***********************************************************************/

using Model.Users;
using Backend.Users.Repository.MySqlRepository;
using System;
using System.Collections.Generic;

namespace Service.GeneralService
{
   public class ArticleService
   {
        public ArticleService(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        private IEnumerable<Article> SortByDate()
        {
             throw new NotImplementedException();
        }

        public bool DeleteArticle(Article article) => articleRepository.Delete(article);

        public Article EditArticle(Article article) => articleRepository.Update(article);

        public Article AddArticle(Article article) => articleRepository.Create(article);
        public IEnumerable<Article> GetAllArticles() => articleRepository.GetAll();
        public Article GetArticle(int id) => articleRepository.GetObject(id);
        public IEnumerable<Article> GetArticlesWroteByDoctor(Doctor doctor) => articleRepository.GetArticlesWroteByDoctor(doctor);

        public IArticleRepository articleRepository;
   
   }
}