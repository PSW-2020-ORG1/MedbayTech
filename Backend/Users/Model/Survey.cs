// File:    Survey.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 2:10:18 AM
// Purpose: Definition of Class Survey

using Backend.General.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Users
{
   public class Survey : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; protected set; }
        public string AdditionalNotes { get; protected set; }
        public Grade AverageGrade { get; protected set; }
        [ForeignKey("Patient")]
        public string PatientId { get; protected set; }
        public virtual Patient Patient { get; set; }
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