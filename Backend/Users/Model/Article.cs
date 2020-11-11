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
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public string DoctorId { get; set; }
        public int PostContentId { get; set; }
        public virtual PostContent PostContent { get; set; }
        public virtual Doctor Doctor { get; set; }

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
            Doctor = author;
        }


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