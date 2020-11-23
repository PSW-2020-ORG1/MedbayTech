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
            Survey postedSurvey = controller.CreateSurvey(survey.SurveyAnswers,survey.Appointment);
            postedSurvey.ShouldNotBeNull();
            
        }

        public static Survey CreateSurvey()
        {

            Survey survey = new Survey
            {
                Id = 2,
                Date = DateTime.Now,
                AppointmentId = 0,
                Appointment = CreateAppointment(),
                SurveyAnswers = CreateListOfQuestions(),
            };
            return survey;
        }
        public static List<SurveyAnswer> CreateListOfQuestions() 
        {
            List<SurveyAnswer> answer = new List<SurveyAnswer>();

            SurveyAnswer answer1 = new SurveyAnswer
            {
                Id = 52,
                SurveyId = 2,
                Survey = null,
                Grade = Grade.excellent,
                SurveyQuestionId = 1,
            };

            answer.Add(answer1);

            return answer;
        }
        public static Appointment CreateAppointment()
        {
            Appointment appointment = new Appointment
            {
                Id = 2,
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 2
            };
            return appointment;
        }

    }
}
