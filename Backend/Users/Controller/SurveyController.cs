// File:    SurveyController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 3:01:24 AM
// Purpose: Definition of Class SurveyController

using Model.Users;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.GeneralController
{
   public class SurveyController
   {
        public SurveyController(SurveyService surveyService)
        {
            this.surveyService = surveyService;
        }

        public Survey CreateSurvey(Survey survey) => surveyService.CreateSurvey(survey);
        public IEnumerable<Survey> GetAllSurveys() => surveyService.GetAllSurveys();
      
        public SurveyService surveyService;
   
   }
}