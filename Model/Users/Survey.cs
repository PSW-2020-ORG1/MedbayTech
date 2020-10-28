// File:    Survey.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 2:10:18 AM
// Purpose: Definition of Class Survey

using System;
using System.Collections.Generic;

namespace Model.Users
{
   public class Survey
   {
        private int id;
        private DateTime date;
        private string additionalNotes;
        private Grade averageGrade;

        private Patient patient;
        private List<SurveyQuestion> surveyQuestions;
      
        public Survey() { }
        public Survey(int id)
        {
            Id = id;
        }

        public Survey(DateTime date, string additionalNotes, Grade averageGrade, List<SurveyQuestion> surveyQuestions)
        {
            Date = date;
            AdditionalNotes = additionalNotes;
            AverageGrade = averageGrade;
            SurveyQuestions = surveyQuestions;
        }


        public DateTime Date { get => date; set => date = value; }
        public string AdditionalNotes { get => additionalNotes; set => additionalNotes = value; }
        public Grade AverageGrade { get => averageGrade; set => averageGrade = value; }
        public int Id { get => id; set => id = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public List<SurveyQuestion> SurveyQuestions { get => surveyQuestions; set => surveyQuestions = value; }
    }
}