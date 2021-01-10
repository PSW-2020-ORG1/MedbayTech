
using System.Collections.Generic;
using Shouldly;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using MedbayTech.Users;
using MedbayTech.Appointment.Application.DTO;
using MedbayTech.Appointment.Domain.Enums;

namespace MedbayTechUnitTests
{
    public class SurveyTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SurveyTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async void Post_survey_integration()
        {
            Console.WriteLine("Hello");
            HttpClient client = _factory.CreateClient();
            var survey = CreateSurvey();
            StringContent content = new StringContent(JsonConvert.SerializeObject(survey), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/survey/createSurvey", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        public static PostSurveyDTO CreateSurvey()
        {

            PostSurveyDTO surveyDTO = new PostSurveyDTO
            {
                appointmentId = 5,
                surveyQuestions = CreateListOfQuestions(),
                surveyAnswers = CreateListOfAnswers(),
            };
            return surveyDTO;
        }

        public static List<int> CreateListOfQuestions()
        {
            List<int> questions = new List<int>();

            questions.Add(1);
            questions.Add(2);
            questions.Add(3);
            questions.Add(4);
            questions.Add(5);
            questions.Add(6);
            questions.Add(7);
            questions.Add(8);
            questions.Add(9);
            questions.Add(10);
            questions.Add(11);
            questions.Add(12);
            questions.Add(13);
            questions.Add(14);
            questions.Add(15);

            return questions;
        }
        public static List<Grade> CreateListOfAnswers()
        {
            List<Grade> answers = new List<Grade>();

            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.veryGood);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);

            return answers;
        }

    }
}