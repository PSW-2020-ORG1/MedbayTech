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
        public int appointmentId { get; set; }
        public List<int> surveyQuestions { get; set; }
        public List<Grade> surveyAnswers { get; set; }

        public PostSurveyDTO() { }
        public PostSurveyDTO(List<int> surveyQuestions, List<Grade> surveyAnswers, int appointmentId)
        {
            this.surveyQuestions = surveyQuestions;
            this.surveyAnswers = surveyAnswers;
            this.appointmentId = appointmentId;         
        }

    }
}
