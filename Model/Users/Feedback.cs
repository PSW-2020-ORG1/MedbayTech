// File:    Feedback.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 2:02:07 AM
// Purpose: Definition of Class Feedback

using System;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SimsProjekat.Repository;

namespace Model.Users
{
   public class Feedback : IIdentifiable<int>
   {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string AdditionalNotes { get; set; }
        public Boolean Approved { get; set; }
        private Boolean Anonymous { get; set; }

        public string RegisteredUserId { get; set; }

       public virtual RegisteredUser RegisteredUser { get; set; }

        public Feedback() { }

        public Feedback(int id)
        {
            Id = id;
        }

        public Feedback(DateTime date, string additionalNotes, Grade everythingInGoodPlace, Boolean anonymous, RegisteredUser user) 
        {
            Date = date;
            AdditionalNotes = additionalNotes;
            RegisteredUser = user;
            Anonymous = anonymous;
            Approved = false;
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