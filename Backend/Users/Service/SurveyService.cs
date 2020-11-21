/***********************************************************************
 * Module:  SurveyService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.SurveyService
 ***********************************************************************/

using Model.Users;
using Backend.Users.Repository.MySqlRepository;
using System;
using System.Collections.Generic;
using Backend.Users.Repository;

namespace Service.GeneralService
{
   public class SurveyService
   {
        public SurveyService(ISurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
        }

        public SurveyService(ISurveyQuestionRepository @object)
        {
            this.@object = @object;
        }

        public SurveyService()
        {
        }

        public Survey CreateSurvey(Survey survey) => surveyRepository.Create(survey);
        public IEnumerable<Survey> GetAllSurveys() => surveyRepository.GetAll();
      
        public ISurveyRepository surveyRepository;
        private ISurveyQuestionRepository @object;
    }
}