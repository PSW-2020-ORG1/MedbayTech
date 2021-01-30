using MedbayTech.Appointment.Domain.Enums;
using System.Collections.Generic;


namespace MedbayTech.Appointment.Application.DTO
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
