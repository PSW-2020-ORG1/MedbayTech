using Backend.Records.Model;
using Moq;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using Model.Users;
using Backend.Records.Model.Enums;
using Backend.Records.WebApiService;
using System.Linq;
using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;

namespace MedbayTechUnitTests
{
    
    public class FeedbackTest
    {
        [Fact]
        public void Find_all_feedbacks()
        {   
            FeedbackService service = new FeedbackService(CreateStubFeedbackRepository());
            IEnumerable<Feedback> feedbacks = service.GetAll();
            
            feedbacks.ShouldNotBeEmpty();
        }

        [Fact]
        public void Save_feedback()
        {
            FeedbackService service = new FeedbackService(CreateStubFeedbackRepository());
            var feedback = CreateFeedback();
            var created_feedback = service.CreateFeedback(feedback.RegisteredUserId, feedback.AdditionalNotes,
                feedback.Anonymous, feedback.AllowedForPublishing);

            created_feedback.ShouldBeNull();
        }

        [Fact]
        public void Get_all_approved_feedback()
        {
            FeedbackService service = new FeedbackService(CreateStubFeedbackRepository());
            var approved_feedbacks = service.GetAllApprovedFeedback();

            approved_feedbacks.Count().ShouldBe(1);
        }

        public static IFeedbackRepository CreateStubFeedbackRepository()
        {
            var stubRepository = new Mock<IFeedbackRepository>();
            var feedbacks = CreateListOfFeedbacks().ToList();
            var feedback = CreateFeedback();
            stubRepository.Setup(p => p.GetAll()).Returns(feedbacks);
            stubRepository.Setup(p => p.Create(feedback)).Returns(feedback);
            
            stubRepository.Setup(p => p.GetAllApprovedFeedback()).Returns(feedbacks.Where(p => p.AllowedForPublishing && p.Approved).ToList());
            return stubRepository.Object;
        }

        private static Feedback CreateFeedback()
        {
            City city = new City(1, "Novi Sad", new State(1, "Srbija"));
            Address address = new Address(1, "Radnicka", 2, 4, 1, city);
            InsurancePolicy insurancePolicy = new InsurancePolicy { Id = "001", Company = "Dunav Osiguranje", StartTime = new DateTime(2015, 1, 1), EndTime = new DateTime(2025, 1, 1) };

            RegisteredUser registeredUser = new RegisteredUser{
                CurrResidence = address, 
                CurrResidenceId = address.Id, 
                DateOfBirth = new DateTime(1975, 6, 9),
                DateOfCreation = DateTime.Now,
                EducationLevel = EducationLevel.bachelor, 
                Email = "test@gmail.com", 
                Gender = Gender.MALE, 
                Id = "id1" , 
                InsurancePolicy = insurancePolicy, 
                InsurancePolicyId = insurancePolicy.Id};


            return new Feedback{ 
                Id=1, 
                AdditionalNotes = "Additional testing notes", 
                AllowedForPublishing = true, 
                Anonymous = true, 
                Approved = false, 
                Date = DateTime.Now, 
                Grade = Grade.poor, 
                RegisteredUser = registeredUser,
                RegisteredUserId = "id1"
            };
        }

        private static List<Feedback> CreateListOfFeedbacks()
        {
            List<Feedback> feedbacks = new List<Feedback>();

            City city = new City(1, "Novi Sad", new State(1, "Srbija"));
            Address address = new Address(1, "Radnicka", 2, 4, 1, city);
            InsurancePolicy insurancePolicy1 = new InsurancePolicy { Id = "001", Company = "Dunav Osiguranje", StartTime = new DateTime(2015, 1, 1), EndTime = new DateTime(2025, 1, 1) };
            InsurancePolicy insurancePolicy2 = new InsurancePolicy { Id = "002", Company = "Dunav Osiguranje", StartTime = new DateTime(2015, 1, 1), EndTime = new DateTime(2025, 1, 1) };

            RegisteredUser registeredUser1 = new RegisteredUser { CurrResidence = address, CurrResidenceId = address.Id, DateOfBirth = new DateTime(1975, 6, 9), DateOfCreation = DateTime.Now, EducationLevel = EducationLevel.bachelor, Email = "test@gmail.com", Gender = Gender.MALE, Id = "id1", InsurancePolicy = insurancePolicy1, InsurancePolicyId = insurancePolicy1.Id };
            RegisteredUser registeredUser2 = new RegisteredUser { CurrResidence = address, CurrResidenceId = address.Id, DateOfBirth = new DateTime(1975, 6, 9), DateOfCreation = DateTime.Now, EducationLevel = EducationLevel.bachelor, Email = "test@gmail.com", Gender = Gender.MALE, Id = "id2", InsurancePolicy = insurancePolicy2, InsurancePolicyId = insurancePolicy2.Id };
            Feedback feedback1 = new Feedback
            {
                Id = 1,
                AdditionalNotes = "Additional testing notes1",
                AllowedForPublishing = false,
                Anonymous = true,
                Approved = false,
                Date = DateTime.Now,
                Grade = Grade.poor,
                RegisteredUser = registeredUser1,
                RegisteredUserId = "id1"
            };

            Feedback feedback2 = new Feedback
            {
                Id = 2,
                AdditionalNotes = "Additional testing notes2",
                AllowedForPublishing = true,
                Anonymous = true,
                Approved = true,
                Date = DateTime.Now,
                Grade = Grade.poor,
                RegisteredUser = registeredUser2,
                RegisteredUserId = "id2"
            };

            feedbacks.Add(feedback1);
            feedbacks.Add(feedback2);

            return feedbacks;
        }
    }
}
