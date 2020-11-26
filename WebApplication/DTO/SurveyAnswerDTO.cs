using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class SurveyAnswerDTO
    {
        public Grade Grade { get; set; }
        public int SurveyQuestionId { get; set; }

        public SurveyAnswerDTO(Grade grade, int surveyQuestionId)
        {
            Grade = grade;
            SurveyQuestionId = surveyQuestionId;
        }
    }
}
