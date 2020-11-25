using Backend.Users.Model.Enums;
using Backend.Users.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Users;
using Moq;
using System.Collections.Generic;
using WebApplicationService.GeneralService;
using Backend.Users.WebApiController;
using Backend.Users.WebApiService;
using Shouldly;
using System;
using System.Text;
using Xunit;
using Backend.Users.Model;
using Model.Schedule;

namespace MedbayTechUnitTests
{
    public class SurveyTest
    {
        [Fact]
        public void Post_survey()
        {
            WebSurveyController controller = new WebSurveyController();
            var survey = CreateSurvey();
            Survey postedSurvey = controller.CreateSurvey(survey.SurveyQuestions, survey.SurveyAnswers, survey.AppointmentId);
            postedSurvey.ShouldNotBeNull();    
        }

        public static Survey CreateSurvey()
        {

            Survey survey = new Survey
            {
                Id = 2,
                Date = DateTime.Now,
                AppointmentId = 1,
                SurveyQuestions = CreateListOfQuestions(),
                SurveyAnswers = CreateListOfAnswers(),
            };
            return survey;
        }
        public static List<int> CreateListOfQuestions() 
        {
            List<int> questions = new List<int>();

            questions.Add(1);

            return questions;
        }
        public static List<Grade> CreateListOfAnswers()
        {
            List<Grade> answers = new List<Grade>();

            answers.Add(Grade.excellent);

            return answers;
        }

    }
}
