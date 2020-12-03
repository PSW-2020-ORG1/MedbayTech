using Backend.Users.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class SurveyQuestionDTO
    {
        public int id { get; set; }
        public string question { get; set; }
        public QuestionType questionType { get; set; }
        public double excellent { get; set; }
        public double veryGood { get; set; }
        public double good { get; set; }
        public double poor { get; set; }
        public double veryPoor { get; set; }
        public double averageGrade { get; set; }

        public SurveyQuestionDTO(int id, string question, QuestionType questionType, double excellent, double veryGood, double good, double poor, double veryPoor, double averageGrade)
        {
            this.id = id;
            this.question = question;
            this.questionType = questionType;
            this.excellent = excellent;
            this.veryGood = veryGood;
            this.good = good;
            this.poor = poor;
            this.veryGood = veryPoor;
            this.averageGrade = averageGrade;

        }
    }
}