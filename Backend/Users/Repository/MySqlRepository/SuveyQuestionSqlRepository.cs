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
        public bool UpdateSurveyQuestion(Survey survey)
        {
            bool r = false;
            foreach (int i in survey.SurveyQuestions)
            {
                SurveyQuestion question = GetObject(i);
                if (!ExistsInSystem(i))
                {
                    r = false;
                }
                else
                {
                    switch (survey.SurveyAnswers.ElementAt(i - 1))
                    {
                        case Grade.excellent:
                            question.Excellent++;
                            r = true;
                            break;
                        case Grade.veryGood:
                            question.VeryGood++;
                            r = true;
                            break;
                        case Grade.good:
                            question.Good++;
                            r = true;
                            break;
                        case Grade.poor:
                            question.Poor++;
                            r = true;
                            break;
                        case Grade.veryPoor:
                            question.VeryPoor++;
                            r = true;
                            break;
                        default:
                            r = false;
                            break;
                    }
                }
                question.CountAverageGrade();
                context.SaveChanges();
            }
            return r;
        }
    }
}
