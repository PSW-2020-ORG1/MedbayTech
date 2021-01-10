using System;
using System.Collections.Generic;
using System.Linq;
using MedbayTech.Feedback.Application.Common.Interfaces.Gateways;
using MedbayTech.Feedback.Domain.Entities;
using MedbayTech.Feedback.Infrastructure.Database;


namespace MedbayTech.Feedback.Infrastructure.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        private IUserGateway _userGateway;

        public FeedbackService(IFeedbackRepository feedbackRepository, IUserGateway userGateway)
        {
            _feedbackRepository = feedbackRepository;
            _userGateway = userGateway;
        }

        public List<Domain.Entities.Feedback> GetAll()
        {
            List<Domain.Entities.Feedback> allFeedback = _feedbackRepository.GetAll().ToList();
            List<User> users = _userGateway.GetUsers();
            allFeedback.ForEach(f => f.RegisteredUser = users.FirstOrDefault(u => f.UserId != null && u.Id.Equals(f.UserId)));

            return allFeedback;
        }

        public List<Domain.Entities.Feedback> GetAllApprovedFeedback()
        {
            List<Domain.Entities.Feedback> approvedFeedback = _feedbackRepository.GetAllApprovedFeedback();
            List<User> users = _userGateway.GetUsers();
            approvedFeedback.ForEach(f => f.RegisteredUser = users.FirstOrDefault(u => f.UserId != null && u.Id.Equals(f.UserId)));
            return approvedFeedback;
        }

        public bool UpdateStatus(int feedbackId, bool status)
        {
            return _feedbackRepository.UpdateStatus(feedbackId, status);
        }
        public Domain.Entities.Feedback CreateFeedback(string userId, string additionalNotes, Boolean anonymous, Boolean allowed)
        {
            Domain.Entities.Feedback feedback = new Domain.Entities.Feedback();
            feedback.AdditionalNotes = additionalNotes;
            feedback.Anonymous = anonymous;
            feedback.AllowedForPublishing = allowed;
            feedback.Date = DateTime.Now;

            if (!anonymous)
            {
                feedback.UserId = userId;
            }

            return _feedbackRepository.Create(feedback);

        }

        public Domain.Entities.Feedback CheckIfExists(Domain.Entities.Feedback feedback)
        {
            List<Domain.Entities.Feedback> feedbacks = _feedbackRepository.GetAll().ToList();
            bool exists = feedbacks.Any(s => s.Id == feedback.Id);
            if (exists)
            {
                return feedbacks.FirstOrDefault(s => s.Id == feedback.Id);
            }
            return null;

        }

    }
}

