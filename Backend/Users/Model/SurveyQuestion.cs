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
        public double Excellent { get; set; }
        public double VeryGood { get; set; }
        public double Good { get; set; }
        public double Poor { get; set; }
        public double VeryPoor { get; set; }
        public double AverageGrade { get; set; }
        public SurveyQuestion() { }

        public SurveyQuestion(int id, string question, QuestionType questionType, Boolean status)
        {
            Question = question;
            QuestionType = questionType;
            Status = status;
            Id = id;
            Excellent = 0;
            VeryGood = 0;
            Good = 0;
            Poor = 0;
            VeryGood = 0;
            AverageGrade = 0.00;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
        public void CountAverageGrade()
        {
            AverageGrade = ((5 * Excellent) + (4 * VeryGood) + (3 * Good) + (2 * Poor) + (1 * VeryPoor)) / (Excellent + VeryGood + Good + Poor + VeryPoor);
        }

    }
}