using Backend.Users.Model;
using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Model;
using Model.Schedule;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.WebApiController
{
    public class WebSurveyController
    {
        private SurveyQuestionSqlRepository surveyQuestionRepository = new SurveyQuestionSqlRepository(new MySqlContext());
        private SurveySqlRepository surveyRepository = new SurveySqlRepository(new MySqlContext());
        private SurveyAnswerSqlRepository surveyAnswerRepository = new SurveyAnswerSqlRepository(new MySqlContext());
        private SurveyService surveyService;

        public WebSurveyController() {
            this.surveyService = new SurveyService(surveyQuestionRepository, surveyRepository, surveyAnswerRepository);
        }

        public IEnumerable<SurveyQuestion> GetAll()
        {
            return surveyService.GetAllQuestions();
        }

        public IEnumerable<SurveyQuestion> GetAllActiveQuestions()
        {
            return surveyService.GetAllActiveQuestions();
        }

        public Survey CreateSurvey(List<int> surveyQuestions, List<Grade> surveyAnswers, int appointmentId)
        {
            return surveyService.CreateSurvey(surveyQuestions, surveyAnswers, appointmentId);
        }
        
        public List<SurveyAnswer> CreateAnswers (List<SurveyAnswer> surveyAnswers)
        {
            return surveyService.CreateAnswers(surveyAnswers);
        }
    }
}
