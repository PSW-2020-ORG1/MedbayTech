// File:    Survey.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 2:10:18 AM
// Purpose: Definition of Class Survey

using Backend.General.Model;
using Backend.Users.Model;
using Model.Schedule;
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
        public DateTime Date { get; set; }
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual List<SurveyAnswer> SurveyAnswers { get; set; }
        
      
        public Survey() { }

        public Survey(int id, DateTime date, Appointment appointment)
        {
            Id = id;
            Date = date;
            SurveyAnswers = new List<SurveyAnswer>();
            Appointment = appointment;
            AppointmentId = appointment.Id;
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