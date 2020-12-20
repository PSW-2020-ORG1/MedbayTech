using Backend.Users.Repository.MySqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Model.Users;
using Backend.Users.Service.Interfaces;

namespace Backend.Users.WebApiService
{
    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        public List<Feedback> GetAll()
        {
            return feedbackRepository.GetAll();
        }

        public List<Feedback> GetAllApprovedFeedback()
        {
            return feedbackRepository.GetAllApprovedFeedback();
        }

        public bool UpdateStatus(int feedbackId, bool status)
        {
            return feedbackRepository.UpdateStatus(feedbackId, status);
        }
        public Feedback CreateFeedback(string userId, string additionalNotes, Boolean anonymous, Boolean allowed)
        {
            Feedback feedback = new Feedback();
            feedback.AdditionalNotes = additionalNotes;
            feedback.Anonymous = anonymous;
            feedback.AllowedForPublishing = allowed;
            feedback.Date = DateTime.Now;

            if (!anonymous)
            {
                feedback.RegisteredUserId = userId;
            }

            return feedbackRepository.Create(feedback);

        }

        public Feedback CheckIfExists(Feedback feedback)
        {
            List<Feedback> feedbacks = feedbackRepository.GetAll().ToList();
            bool exists = feedbacks.Any(s => s.Id == feedback.Id);
            if (exists)
            {
                return feedbacks.FirstOrDefault(s => s.Id == feedback.Id);
            }
            return null;



        }

    }
}
