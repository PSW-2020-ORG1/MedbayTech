using Backend.Users.Model;
using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PostSurveyDTO
    {
        public Appointment Appointment { get; set; }
        public List<SurveyAnswer> SurveyAnswers { get; set; }
        public PostSurveyDTO() { }
        public PostSurveyDTO(Appointment appointment, List<SurveyAnswer> surveyAnswers)
        {
            Appointment = appointment;
            SurveyAnswers = surveyAnswers;
        }

    }
}
