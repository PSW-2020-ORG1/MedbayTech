// File:    QuestionReply.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 2:07:27 AM
// Purpose: Definition of Class QuestionReply

using System;

namespace Model.Users
{
   public class QuestionReply
   {

        public int Id { get; protected set; }
        public DateTime Date { get; protected set; }
        public string Content { get; protected set; }
        public virtual Doctor Author { get; set; }
        public string AuthorId { get; protected set; }

        public QuestionReply() { }

        public QuestionReply(int Id, DateTime date, string content, Doctor author)
        {
            Date = date;
            Content = content;
            Author = author;
            AuthorId = author.Id;
        }

    }
}