using Backend.Users.Model;
using Backend.Users.Repository;
using Backend.Users.Repository.MySqlRepository;
using Model.Schedule;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.WebApiService
{
    public class SurveyService
    {
        private ISurveyQuestionRepository surveyQuestionRepository;
        private ISurveyRepository surveyRepository;
        private ISurveyAnswerRepository surveyAnswerRepository;

        public SurveyService(ISurveyQuestionRepository surveyQuestionRepository, ISurveyRepository surveyRepository, ISurveyAnswerRepository surveyAnswerRepository) {
            this.surveyQuestionRepository = surveyQuestionRepository;
            this.surveyRepository = surveyRepository;
            this.surveyAnswerRepository = surveyAnswerRepository;
        }

        public IEnumerable<SurveyQuestion> GetAllQuestions()
        {
            return surveyQuestionRepository.GetAll();
        }

        public IEnumerable<SurveyQuestion> GetAllActiveQuestions()
        {
            return surveyQuestionRepository.GetAllActiveQuestions();
        }

        public IEnumerable<SurveyAnswer> GetAllAnswers()
        {
            return surveyAnswerRepository.GetAll();
        }

        public Survey CreateSurvey(List<int> surveyQuestions, List<Grade> surveyAnswers, int appointmentId)
        {
            

            Survey survey = new Survey();
            survey.AppointmentId = appointmentId;
            survey.Date = DateTime.Now;
            survey.SurveyQuestions = surveyQuestions;
            survey.SurveyAnswers = surveyAnswers;
   
            Survey createdSurvey = surveyRepository.Create(survey);

            return createdSurvey;
        }

        public List<SurveyAnswer> CreateAnswers(List<SurveyAnswer> surveyAnswers) 
        {
            List<SurveyAnswer> answers = new List<SurveyAnswer>();
            foreach (SurveyAnswer answer in surveyAnswers) {
                answers.Add(surveyAnswerRepository.Create(answer));
            }
            return answers;
        }

        public int GenerateSurveyId()
        {      
            int id;
            if (surveyRepository.GetAll() == null)
            {
                id = 1;
                return id;
            }
            id = surveyRepository.GetLastId();
            return ++id;
        }
    }
}
