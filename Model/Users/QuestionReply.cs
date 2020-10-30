// File:    QuestionReply.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 2:07:27 AM
// Purpose: Definition of Class QuestionReply

using System;

namespace Model.Users
{
   public class QuestionReply
   {
        private int id;
        private DateTime date;
        private string content;
      
        public Doctor author;

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


        public DateTime Date { get => date; set => date = value; }
        public string Content { get => content; set => content = value; }
        public Doctor Author { get => author; set => author = value; }
        public int Id { get => id; set => id = value; }
    }
}