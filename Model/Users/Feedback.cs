// File:    Feedback.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 2:02:07 AM
// Purpose: Definition of Class Feedback

using System;

namespace Model.Users
{
   public class Feedback
   {
        private int id;
        private DateTime date;
        private string additionalNotes;
       // private Grade softwareGrade;
        private Grade everythingInGoodPlace;
        private Boolean approved;
        private Boolean anonymous;

       public RegisteredUser registeredUser;

        public Feedback() { }

        public Feedback(int id)
        {
            Id = id;
        }

        public Feedback(DateTime date, string additionalNotes, Grade everythingInGoodPlace, Boolean anonymous, RegisteredUser user) // Grade softwareGrade )
        {
            Date = date;
            AdditionalNotes = additionalNotes;
         //   SoftwareGrade = softwareGrade;
            EverythingInGoodPlace = everythingInGoodPlace;
            RegisteredUser = user;
            Anonymous = anonymous;
            Approved = false;
        }

        public DateTime Date { get => date; set => date = value; }
        public string AdditionalNotes { get => additionalNotes; set => additionalNotes = value; }
     //   public Grade SoftwareGrade { get => softwareGrade; set => softwareGrade = value; }
        public Grade EverythingInGoodPlace { get => everythingInGoodPlace; set => everythingInGoodPlace = value; }
        public RegisteredUser RegisteredUser { get => registeredUser; set => registeredUser = value; }
        public int Id { get => id; set => id = value; }
        public Boolean Anonymous { get => anonymous; set => anonymous = value; }
        public Boolean Approved { get => approved; set => approved = value; }


    }
}