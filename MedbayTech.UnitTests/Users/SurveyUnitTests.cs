using Backend.Users.Repository;
using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Model.Users;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MedbayTechUnitTests
{
    public class SurveyUnitTests
    {
        [Fact]
        public void Same_appointment_id()
        {
           
            SurveyService service = new SurveyService(CreateQuestionStubRepository(), CreateSurveyStubRepository());
            bool b = service.CheckIfExistsById(2);
            b.ShouldBeFalse();
        }

        [Fact]
        public void Different_appointment_id()
        {

            SurveyService service = new SurveyService(CreateQuestionStubRepository(), CreateSurveyStubRepository());
            bool b = service.CheckIfExistsById(4);
            b.ShouldBeTrue(); 
        }

        private static ISurveyRepository CreateSurveyStubRepository()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var surveys = new List<Survey>();
            var survey = CreateSurvey();
            surveys.Add(survey);

            stubRepository.Setup(m => m.GetAll()).Returns(surveys);
            stubRepository.Setup(m => m.Create(survey)).Returns(survey);
            return stubRepository.Object;
        }
        private static ISurveyQuestionRepository CreateQuestionStubRepository()
        {
            var stubRepository = new Mock<ISurveyQuestionRepository>();
            var surveyQuestions = new List<SurveyQuestion>();
            var survey = CreateSurvey();

            stubRepository.Setup(m => m.GetAll()).Returns(surveyQuestions);
            stubRepository.Setup(m => m.UpdateSurveyQuestion(survey)).Returns(true);
            return stubRepository.Object;
        }
        private static List<int> CreateSurveyQuestions()
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

        public static List<Grade> CreateSurveyAnswers()
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
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);
            answers.Add(Grade.excellent);

            return answers;
        }
        public static Survey CreateSurvey()
        {
            Survey s = new Survey
            {
                Appointment = null,
                AppointmentId = 2,
                Date = DateTime.Now,
                Id = 1,
                SurveyAnswers = CreateSurveyAnswers(),
                SurveyQuestions = CreateSurveyQuestions()
            };
            return s;
        }
    }
}