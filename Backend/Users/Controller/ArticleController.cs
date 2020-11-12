// File:    ArticleController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:57:28 AM
// Purpose: Definition of Class ArticleController

using Model.Users;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.GeneralController
{
    public class ArticleController
    {
        public ArticleController(ArticleService articleService)
        {
            this.articleService = articleService;
        }
        public bool DeleteArticle(Article article) => articleService.DeleteArticle(article);
        public Article EditArticle(Article article) => articleService.EditArticle(article);
        public Article AddArticle(Article article) => articleService.AddArticle(article);
        public IEnumerable<Article> GetAllArticles() => articleService.GetAllArticles();
        public Article GetArticle(int id) => articleService.GetArticle(id);
        public IEnumerable<Article> GetArticlesWroteByDoctor(Doctor doctor) => articleService.GetArticlesWroteByDoctor(doctor);

        public ArticleService articleService;
  
   
   }
}