using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Repository;
using System;
using System.Collections.Generic;


namespace MedbayTech.Appointment.Application.Common.Interfaces.Persistance
{
    public interface ISurveyQuestionRepository : IRepository<SurveyQuestion, int>
    {
        public List<SurveyQuestion> GetAllActiveQuestions();
        public bool UpdateSurveyQuestion(Survey survey);
    }
}
