// File:    SurveyQuestion.cs
// Author:  Vlajkov
// Created: Tuesday, April 21, 2020 2:47:03 PM
// Purpose: Definition of Class SurveyQuestion

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Users
{
   public class SurveyQuestion
   {
        [Key]
        public int Id { get; protected set; }
        public string Question { get; protected set; }
        public Grade Grade { get; protected set; }
        [ForeignKey("Survey")]
        public int SurveyId { get; protected set; }
        public virtual Survey Survey { get; protected set; }

        public SurveyQuestion() { }

        public SurveyQuestion(int id, string question, Grade grade, Survey survey)
        {
            Question = question;
            Grade = grade;
            Survey = survey;
            SurveyId = survey.Id;
            Id = id;
        }

    }
}