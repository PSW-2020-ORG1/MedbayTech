// File:    Question.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 2:03:50 AM
// Purpose: Definition of Class Question

using System;
using SimsProjekat.Repository;

namespace Model.Users
{
   public class Question : IIdentifiable<int>
   {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool FrequentlyAsked { get; set; }
        public virtual Patient Author { get; set; }
        public string AuthorId { get; set; }
        public virtual PostContent PostContent { get; set; }
        public int PostContentId { get; set; }
        public QuestionReply QuestionReply { get; set; }
        public int QuestionReplyId { get; set; }

        public Question() 
        {
            PostContent = new PostContent();
            QuestionReply = new QuestionReply();
        }
        public Question(int id)
        {
            PostContent = new PostContent();
            QuestionReply = new QuestionReply();
            Id = id;
        }

        public Question(DateTime date, bool frequentlyAsked, Patient author, PostContent postContent)
        {
            Date = date;
            FrequentlyAsked = frequentlyAsked;
            Author = author;
            PostContent = postContent;
            QuestionReply = new QuestionReply();
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