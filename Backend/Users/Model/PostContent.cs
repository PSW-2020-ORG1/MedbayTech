// File:    PostContent.cs
// Author:  Vlajkov
// Created: Sunday, April 12, 2020 12:13:27 AM
// Purpose: Definition of Class PostContent

using System;

namespace Model.Users
{
   public class PostContent
   {

        public int Id { get; set; }
        public string Content { get; set; }
        public string ContentTitle { get; set; }

        public PostContent() { }
        public PostContent(int id)
        {
            Id = id;
        }

        public PostContent(string content, string contentTitle)
        {
            Content = content;
            ContentTitle = contentTitle;
        }
    }
}