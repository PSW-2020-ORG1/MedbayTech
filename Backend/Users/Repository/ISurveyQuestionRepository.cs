using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository
{
    public interface ISurveyQuestionRepository : IGetAll<SurveyQuestion>
    {
        public IEnumerable<SurveyQuestion> GetAllActiveQuestions();
        public bool UpdateSurveyQuestion(Survey survey);
    }
}
