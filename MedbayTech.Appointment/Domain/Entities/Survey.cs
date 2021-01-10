using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Appointment.Domain.Enums;
using MedbayTech.Common.Domain.Entities;


namespace MedbayTech.Appointment.Domain.Entities
{
   public class Survey : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public List<int> SurveyQuestions { get; set; }
        public List<Grade> SurveyAnswers { get; set; }
        
      
        public Survey() { }

        public Survey(int id, DateTime date, Appointment appointment)
        {
            Id = id;
            Date = date;
            SurveyQuestions = new List<int>();
            SurveyAnswers = new List<Grade>();
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