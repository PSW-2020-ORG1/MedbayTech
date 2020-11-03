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
      private int id;
      private DateTime date;
      private bool frequentlyAsked;
      
      private Patient author;
      private PostContent postContent;
      private QuestionReply questionReply;

      public string authorId;
      public int postContentId;
      public int questionReplyId;

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


        public DateTime Date { get => date; set => date = value; }
        public bool FrequentlyAsked { get => frequentlyAsked; set => frequentlyAsked = value; }
        public virtual Patient Author { get => author; set => author = value; }
        public virtual PostContent PostContent { get => postContent; set => postContent = value; }
        public virtual QuestionReply QuestionReply { get => questionReply; set => questionReply = value; }
        public int Id { get => id; set => id = value; }

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