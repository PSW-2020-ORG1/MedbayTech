// File:    PostContent.cs
// Author:  Vlajkov
// Created: Sunday, April 12, 2020 12:13:27 AM
// Purpose: Definition of Class PostContent

using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Users
{
   public class PostContent
   {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string ContentTitle { get; set; }

        public PostContent() { }

        public PostContent(int id, string content, string contentTitle)
        {
            Id = id;
            Content = content;
            ContentTitle = contentTitle;
        }
    }
}