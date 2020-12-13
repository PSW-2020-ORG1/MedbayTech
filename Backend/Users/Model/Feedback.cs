// File:    Feedback.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 2:02:07 AM
// Purpose: Definition of Class Feedback

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.General.Model;

namespace Model.Users
{
    public class Feedback : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; } 
        public DateTime Date { get;  set; }

        public string AdditionalNotes { get; set; }
        public bool Approved { get; set; }
        public bool Anonymous { get; set; }
        public bool AllowedForPublishing { get; set; }
        public Grade Grade { get; set; }
        [ForeignKey("RegisteredUser")]
        public string RegisteredUserId { get; set; }
        public virtual RegisteredUser RegisteredUser { get; set; }

        public Feedback() { }

        public Feedback(int id, DateTime date, string additionalNotes, Grade grade, bool anonymous, bool allowedForPublishing, RegisteredUser user) 
        {
            Id = id;
            Date = date;
            AdditionalNotes = additionalNotes;
            Grade = grade;
            RegisteredUser = user;
            RegisteredUserId = user.Id;
            Anonymous = anonymous;
            Approved = false;
            AllowedForPublishing = allowedForPublishing;
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