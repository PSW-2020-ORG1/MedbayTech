using Model.Users;
using Repository;
using System.Collections.Generic;

namespace Backend.Users.Repository
{
    public interface ISurveyQuestionRepository : IGetAll<SurveyQuestion>
    {
        public List<SurveyQuestion> GetAllActiveQuestions();
        public bool UpdateSurveyQuestion(Survey survey);
    }
}
