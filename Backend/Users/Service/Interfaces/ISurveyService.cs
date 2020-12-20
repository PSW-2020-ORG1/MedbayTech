using Model.Users;
using System.Collections.Generic;

namespace Backend.Users.Service.Interfaces
{
    public interface ISurveyService
    {
        List<SurveyQuestion> GetAllQuestions();
        List<SurveyQuestion> GetAllActiveQuestions();
        List<Survey> GetAllSurveys();
        bool CheckIfExistsById(int appointmentId);
        Survey CreateSurvey(List<int> surveyQuestions, List<Grade> surveyAnswers, int appointmentId);
    }
}
