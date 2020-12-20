using Backend.Users.Model;
using Backend.Users.Repository;
using Backend.Users.Repository.MySqlRepository;
using Backend.Users.Service.Interfaces;
using Model.Schedule;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.WebApiService
{
    public class SurveyService : ISurveyService
    {
        private ISurveyQuestionRepository surveyQuestionRepository;
        private ISurveyRepository surveyRepository;

        public SurveyService(ISurveyQuestionRepository surveyQuestionRepository, ISurveyRepository surveyRepository) {
            this.surveyQuestionRepository = surveyQuestionRepository;
            this.surveyRepository = surveyRepository;
        }

        public List<SurveyQuestion> GetAllQuestions()
        {
            return surveyQuestionRepository.GetAll();
        }

        public List<SurveyQuestion> GetAllActiveQuestions()
        {
            return surveyQuestionRepository.GetAllActiveQuestions();
        }

        public List<Survey> GetAllSurveys()
        {
            return surveyRepository.GetAll();
        }

        public bool CheckIfExistsById(int appointmentId)
        {
            List<Survey> surveys = surveyRepository.GetAll().ToList();
            foreach (Survey s in surveys)
            {
                if (s.AppointmentId == appointmentId)
                {
                    return false;
                }
            }
            return true;
        }

        public Survey CreateSurvey(List<int> surveyQuestions, List<Grade> surveyAnswers, int appointmentId)
        {
            if (!CheckIfExistsById(appointmentId))
            {
                return null;
            }
            Survey survey = new Survey();
            survey.AppointmentId = appointmentId;
            survey.Date = DateTime.Now;
            survey.SurveyQuestions = surveyQuestions;
            survey.SurveyAnswers = surveyAnswers;
            Survey createdSurvey = surveyRepository.Create(survey);
            bool update = surveyQuestionRepository.UpdateSurveyQuestion(createdSurvey);       
            if (!update)
            {
                return null;
            }
            return createdSurvey;
        }   
    }
}
