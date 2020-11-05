// File:    SurveyQuestion.cs
// Author:  Vlajkov
// Created: Tuesday, April 21, 2020 2:47:03 PM
// Purpose: Definition of Class SurveyQuestion

using System;

namespace Model.Users
{
   public class SurveyQuestion
   {
        public int Id { get; set; }
        public string Question { get; set; }
        public Grade grade { get; set; }

        public int gradeId;

        public virtual Survey Survey { get; set; }

        public SurveyQuestion() { }
        public SurveyQuestion(int id)
        {
            Id = id;
        }

        public SurveyQuestion(string question, Grade grade)
        {
            Question = question;
            Grade = grade;
        }


        public virtual Grade Grade { get => grade; set => grade = value; }

    }
}