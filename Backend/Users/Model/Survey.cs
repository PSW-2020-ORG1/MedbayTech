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
        public DateTime Date { get; protected set; }
        public string AdditionalNotes { get; protected set; }
        public Grade AverageGrade { get; protected set; }
        public virtual Patient Patient { get; set; }
        public string PatientId { get; protected set; }
        public virtual List<SurveyQuestion> SurveyQuestions { get; set; }
        
      
        public Survey() { }

        public Survey(int id, DateTime date, string additionalNotes, Grade averageGrade, Patient patient)
        {
            Date = date;
            AdditionalNotes = additionalNotes;
            AverageGrade = averageGrade;
            SurveyQuestions = new List<SurveyQuestion>();
            Patient = patient;
            PatientId = patient.Id;
        }

    }
}