// File:    Article.cs
// Author:  Vlajkov
// Created: Thursday, April 09, 2020 2:12:58 AM
// Purpose: Definition of Class Article

using System;
using SimsProjekat.Repository;

namespace Model.Users
{
   public class Article : IIdentifiable<int>
   {
        int id;
        private DateTime date;
        private string image;
        public string doctorId;
        public int postContentId;

        public PostContent postContent;
        public Doctor author;

        public Article() 
        {
            PostContent = new PostContent();
        }
        public Article(int id)
        {
            Id = id;
        }
        public Article(DateTime date, PostContent postContent, Doctor author)
        {
            Date = date;
            PostContent = postContent;
            Author = author;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Image { get => image; set => image = value; }
        public virtual PostContent PostContent { get => postContent; set => postContent = value; }
        public virtual Doctor Author { get => author; set => author = value; }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}