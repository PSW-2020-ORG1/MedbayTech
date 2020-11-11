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

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string AdditionalNotes { get; set; }
        public Grade AverageGrade { get; set; }
        public virtual Patient Patient { get; set; }
        public string PatientId { get; set; }
        public virtual List<SurveyQuestion> SurveyQuestions { get; set; }
        
      
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

    }
}