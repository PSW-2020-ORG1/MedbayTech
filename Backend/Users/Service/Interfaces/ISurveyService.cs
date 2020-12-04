using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service.Interfaces
{
    public interface ISurveyService
    {
        IEnumerable<SurveyQuestion> GetAllQuestions();
        IEnumerable<SurveyQuestion> GetAllActiveQuestions();
        IEnumerable<Survey> GetAllSurveys();
        bool CheckIfExistsById(int appointmentId);
        Survey CreateSurvey(List<int> surveyQuestions, List<Grade> surveyAnswers, int appointmentId);
    }
}
