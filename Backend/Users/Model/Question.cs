// File:    Question.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 2:03:50 AM
// Purpose: Definition of Class Question

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.General.Model;

namespace Model.Users
{
   public class Question : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; protected set; }
        public bool FrequentlyAsked { get; set; }
        [ForeignKey("Author")]
        public string AuthorId { get; protected set; }
        public virtual Patient Author { get; set; }
        public virtual PostContent PostContent { get; protected set; }
        public int PostContentId { get; protected set; }
        private QuestionReply _questionReply;
        public int QuestionReplyId { get; set; }

        public Question() 
        {
            PostContent = new PostContent();
            QuestionReply = new QuestionReply();
        }

        public Question(int id, DateTime date, bool frequentlyAsked, Patient author, PostContent postContent)
        {
            Date = date;
            FrequentlyAsked = frequentlyAsked;
            Author = author;
            AuthorId = author.Id;
            PostContent = postContent;
            PostContentId = postContent.Id;
        }
        public virtual QuestionReply QuestionReply 
        {
            get => _questionReply;
            set
            {
                _questionReply = value;
                QuestionReplyId = value.Id;
            }
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