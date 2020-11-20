using Model;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    public class SurveyQuestionSqlRepository : MySqlrepository<SurveyQuestion, int>,
        ISurveyQuestionRepository
    {
        public SurveyQuestionSqlRepository(MySqlContext context) : base(context) { }

        public IEnumerable<SurveyQuestion> GetAllActiveQuestions()
        {
            return GetAll().Where(surveyQuestion => surveyQuestion.Status == true);

        }
    }
}
