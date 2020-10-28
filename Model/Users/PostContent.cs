// File:    PostContent.cs
// Author:  Vlajkov
// Created: Sunday, April 12, 2020 12:13:27 AM
// Purpose: Definition of Class PostContent

using System;

namespace Model.Users
{
   public class PostContent
   {
        private int id;
      private string content;
      private string contentTitle;

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

        public string Content { get => content; set => content = value; }
        public string ContentTitle{ get => contentTitle; set => contentTitle = value; }
        public int Id { get => id; set => id = value; }
    }
}