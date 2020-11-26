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
        public void In_range_grade()
        {
            SurveyService service = new SurveyService(CreateQuestionStubRepository(), CreateSurveyStubRepository());
            Survey s = service.CreateSurvey(CreateSurveyQuestions(), CreateSurveyAnswers(), 1);
            s.ShouldBeNull();

        }

        private static ISurveyRepository CreateSurveyStubRepository()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var surveys = new List<Survey>();

            stubRepository.Setup(m => m.GetAll()).Returns(surveys);
            return stubRepository.Object;
        }
        private static ISurveyQuestionRepository CreateQuestionStubRepository()
        {
            var stubRepository = new Mock<ISurveyQuestionRepository>();
            var surveyQuestions = new List<SurveyQuestion>();

            stubRepository.Setup(m => m.GetAll()).Returns(surveyQuestions);
            return stubRepository.Object;
        }
        private static List<int> CreateSurveyQuestions()
        {
            List<int> questions = new List<int>();

            questions.Add(1);

            return questions;
        }
        
        public static List<Grade> CreateSurveyAnswers()
        {
            List<Grade> answers = new List<Grade>();

            answers.Add(Grade.excellent);

            return answers;
        }
    }
}
