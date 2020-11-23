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

        public SurveyService(ISurveyQuestionRepository surveyQuestionRepository, ISurveyRepository surveyRepository) {
            this.surveyQuestionRepository = surveyQuestionRepository;
            this.surveyRepository = surveyRepository;
        }

        public IEnumerable<SurveyQuestion> GetAllQuestions()
        {
            return surveyQuestionRepository.GetAll();
        }

        public IEnumerable<SurveyQuestion> GetAllActiveQuestions()
        {
            return surveyQuestionRepository.GetAllActiveQuestions();
        }
        public Survey CreateSurvey(List<SurveyAnswer> surveyAnswers, Appointment appointment)
        {
            
            int surveyId = GenerateSurveyId();
            Survey survey = new Survey();
            survey.AppointmentId = appointment.Id;
            survey.Appointment = appointment;
            survey.Date = DateTime.Now;
            survey.SurveyAnswers = surveyAnswers;
   
            Survey createdSurvey = surveyRepository.Create(survey);

            return createdSurvey;
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
