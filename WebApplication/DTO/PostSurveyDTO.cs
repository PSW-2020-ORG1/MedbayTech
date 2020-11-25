using Backend.Users.Model;
using Model.Schedule;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PostSurveyDTO
    {
        public int AppointmentId { get; set; }
        public List<int> SurveyQuestions { get; set; }
        public List<Grade> SurveyAnswers { get; set; }

        public PostSurveyDTO() { }
        public PostSurveyDTO(List<int> surveyQuestions, List<Grade> surveyAnswers, int appointmentId)
        {
            SurveyQuestions = surveyQuestions;
            SurveyAnswers = surveyAnswers;
            AppointmentId = appointmentId;         
        }

    }
}
