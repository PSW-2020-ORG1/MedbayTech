using MedbayTech.Feedback.Application.Common.Interfaces.Gateways;
using MedbayTech.Feedback.Domain.Entities;
using MedbayTech.Feedback.Infrastructure.Database;
using MedbayTech.Feedback.Infrastructure.Services;
using Model.Users;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MedbayTech.UnitTesting.Users
{
    public class FeedbackTest
    {
        [Fact]
        public void Find_all_feedbacks()
        {
            FeedbackService service = new FeedbackService(CreateStubFeedbackRepository(), CreateUserGateway());
            IEnumerable<Feedback.Domain.Entities.Feedback> feedbacks = service.GetAll();

            feedbacks.ShouldNotBeEmpty();
        }

        [Fact]
        public void Save_feedback()
        {
            FeedbackService service = new FeedbackService(CreateStubFeedbackRepository(), CreateUserGateway());
            var feedback = CreateFeedback();
            var created_feedback = service.CreateFeedback(feedback.UserId, feedback.AdditionalNotes,
                feedback.Anonymous, feedback.AllowedForPublishing);

            created_feedback.ShouldBeNull();
        }

        [Fact]
        public void Get_all_approved_feedback()
        {
            FeedbackService service = new FeedbackService(CreateStubFeedbackRepository(), CreateUserGateway());
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
        public static IUserGateway CreateUserGateway()
        {
            var userGateway = new Mock<IUserGateway>();
            List<User> users = CreateUserList();
            userGateway.Setup(u => u.GetUsers()).Returns(users);
            return userGateway.Object;

        }

        private static List<User> CreateUserList()
        {
            List<User> users = new List<User>();
            
            User registeredUser1 = new User
            {
                Name = "Petar",
                Surname = "Petrovic",
                Id = "id1"

            };
            User registeredUser2 = new User
            {
                Name = "Jovan",
                Surname = "Petrovic",
                Id = "id2"

            };

            users.Add(registeredUser2);
            users.Add(registeredUser1);
            return users;
        }


        private static Feedback.Domain.Entities.Feedback CreateFeedback()
        {

            User registeredUser = new User
            {
                Name = "Petar",
                Surname = "Petrovic",
                Id = "id1"
            };


            return new Feedback.Domain.Entities.Feedback
            {
                Id = 1,
                AdditionalNotes = "Additional testing notes",
                AllowedForPublishing = true,
                Anonymous = true,
                Approved = false,
                Date = DateTime.Now,
                UserId = "id1"
            };
        }

        private static List<Feedback.Domain.Entities.Feedback> CreateListOfFeedbacks()
        {
            List<Feedback.Domain.Entities.Feedback> feedbacks = new List<Feedback.Domain.Entities.Feedback>();
            User registeredUser1 = new User
            {
                Name = "Petar",
                Surname = "Petrovic",
                Id = "id1"

            };
            User registeredUser2 = new User
            {
                Name = "Jovan",
                Surname = "Petrovic",
                Id = "id2"

            };

            Feedback.Domain.Entities.Feedback feedback1 = new Feedback.Domain.Entities.Feedback
            {
                Id = 1,
                AdditionalNotes = "Additional testing notes1",
                AllowedForPublishing = false,
                Anonymous = true,
                Approved = false,
                Date = DateTime.Now,
                UserId = "id1"
            };

            Feedback.Domain.Entities.Feedback feedback2 = new Feedback.Domain.Entities.Feedback
            {
                Id = 2,
                AdditionalNotes = "Additional testing notes2",
                AllowedForPublishing = true,
                Anonymous = true,
                Approved = true,
                Date = DateTime.Now,
                UserId = "id2"
            };

            feedbacks.Add(feedback1);
            feedbacks.Add(feedback2);

            return feedbacks;
        }
    }
}
