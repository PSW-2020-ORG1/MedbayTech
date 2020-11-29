using Backend.Users.Model.Enums;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Adapters
{
    public class SurveyAdapter
    {
        public static List<SurveyQuestionDTO> ListActiveQuestionsToListSurveyQuestionDTO(List<SurveyQuestion> activeQuestions)
        {
            List<SurveyQuestionDTO> activeQuestionsList = new List<SurveyQuestionDTO>();
            foreach (SurveyQuestion questionIt in activeQuestions)
            {
                int id = questionIt.Id;
                string question = questionIt.Question;
                QuestionType questionType = questionIt.QuestionType;
                double excellent = questionIt.Excellent;
                double veryGood = questionIt.VeryGood;
                double good = questionIt.Good;
                double poor = questionIt.Poor;
                double veryPoor = questionIt.VeryPoor;
                double averageGrade = questionIt.AverageGrade;
                activeQuestionsList.Add(new SurveyQuestionDTO(id, question, questionType, excellent, veryGood, good, poor, veryPoor, averageGrade));
            }

            return activeQuestionsList;


        }
    }
}