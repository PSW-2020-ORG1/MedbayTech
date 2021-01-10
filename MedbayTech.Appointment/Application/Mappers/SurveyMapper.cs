using MedbayTech.Appointment.Application.DTO;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Appointment.Domain.Enums;
using System.Collections.Generic;

namespace MedbayTech.Appointment.Application.Mappers
{
    public class SurveyMapper
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
