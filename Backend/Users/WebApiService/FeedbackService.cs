using Backend.Users.Repository.MySqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Model.Users;

namespace Backend.Users.WebApiService
{
    public class FeedbackService
    {
        private IFeedbackRepository feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        public IEnumerable<Feedback> GetAll()
        {
            return feedbackRepository.GetAll();
        }

        public IEnumerable<Feedback> GetAllApprovedFeedback()
        {
            return feedbackRepository.GetAllApprovedFeedback();
        }

        public bool UpdateStatus(int feedbackId, bool status)
        {
            return feedbackRepository.UpdateStatus(feedbackId, status);
        }
        public Feedback CreateFeedback(string userId, string additionalNotes, Boolean anonymous, Boolean allowed)
        {
            int feedbackId = GenerateFeedbackId();
            Feedback feedback = new Feedback();
            feedback.Id = feedbackId;
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

        public int GenerateFeedbackId()
        {
            int id;
            id = feedbackRepository.GetLastId();
            return ++id;
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
