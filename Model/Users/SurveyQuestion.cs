// File:    SurveyQuestion.cs
// Author:  Vlajkov
// Created: Tuesday, April 21, 2020 2:47:03 PM
// Purpose: Definition of Class SurveyQuestion

using System;

namespace Model.Users
{
   public class SurveyQuestion
   {
        private int id;
        private string question;
        private Grade grade;

        public int gradeId;

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


        public string Question { get => question; set => question = value; }
        public virtual Grade Grade { get => grade; set => grade = value; }
        public int Id { get => id; set => id = value; }

    }
}