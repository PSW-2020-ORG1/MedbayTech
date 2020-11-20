// File:    SurveyQuestion.cs
// Author:  Vlajkov
// Created: Tuesday, April 21, 2020 2:47:03 PM
// Purpose: Definition of Class SurveyQuestion

using Backend.Users.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.General.Model;

namespace Model.Users
{
   public class SurveyQuestion : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public QuestionType QuestionType { get; set; }
        public Boolean Status { get; set; }
        public SurveyQuestion() { }

        public SurveyQuestion(int id, string question, QuestionType questionType, Boolean status)
        {
            Question = question;
            QuestionType = questionType;
            Status = status;
            Id = id;
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