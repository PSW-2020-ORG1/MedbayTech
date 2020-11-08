// File:    QuestionReply.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 2:07:27 AM
// Purpose: Definition of Class QuestionReply

using System;

namespace Model.Users
{
   public class QuestionReply
   {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public virtual Doctor Author { get; set; }
        public string AuthorId { get; set; }

        public QuestionReply() { }
        public QuestionReply(int id)
        {
            Id = id;
        }

        public QuestionReply(DateTime date, string content, Doctor author)
        {
            Date = date;
            Content = content;
            Author = author;
        }

    }
}