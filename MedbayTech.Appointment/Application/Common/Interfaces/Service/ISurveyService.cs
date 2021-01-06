using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Appointment.Domain.Enums;
using System.Collections.Generic;


namespace MedbayTech.Appointment.Application.Common.Interfaces.Persistance
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
