using Backend.Users.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class SurveyQuestionDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public QuestionType QuestionType { get; set; }

        public SurveyQuestionDTO(int id, string question, QuestionType questionType)
        {
            Id = id;
            Question = question;
            QuestionType = questionType;
        
        }
    }
}
