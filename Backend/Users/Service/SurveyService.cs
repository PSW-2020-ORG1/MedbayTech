/***********************************************************************
 * Module:  SurveyService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.SurveyService
 ***********************************************************************/

using Model.Users;
using Backend.Users.Repository.MySqlRepository;
using System;
using System.Collections.Generic;

namespace Service.GeneralService
{
   public class SurveyService
   {
        public SurveyService(ISurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
        }

        public Survey CreateSurvey(Survey survey) => surveyRepository.Create(survey);
        public IEnumerable<Survey> GetAllSurveys() => surveyRepository.GetAll();
      
        public ISurveyRepository surveyRepository;
   
   }
}