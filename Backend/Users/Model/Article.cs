// File:    Article.cs
// Author:  Vlajkov
// Created: Thursday, April 09, 2020 2:12:58 AM
// Purpose: Definition of Class Article

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.General.Model;

namespace Model.Users
{
   public class Article : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; protected set; }
        public string Image { get; protected set; }
        [ForeignKey("PostContent")]
        public int PostContentId { get; protected set; }
        public virtual PostContent PostContent { get; protected set; }
        [ForeignKey("Doctor")]
        public string DoctorId { get; protected set; }
        public virtual Doctor Doctor { get; set; }

        public Article() 
        {
            PostContent = new PostContent();
        }

        public Article(int id, DateTime date, string image, PostContent postContent, Doctor doctor)
        {
            Id = id;
            Date = date;
            Image = image;
            PostContent = postContent;
            PostContentId = postContent.Id;
            Doctor = doctor;
            DoctorId = doctor.Id;
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