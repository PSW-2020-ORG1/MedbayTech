using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.WebApiController
{
    public class WebFeedbackController
    {
        
        private FeedbackSqlRepository feedbackRepository = new FeedbackSqlRepository(new MySqlContext());
        private FeedbackService feedbackService;
        public WebFeedbackController()
        {
            this.feedbackService = new FeedbackService(feedbackRepository);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return feedbackService.GetAll();
        }

        public IEnumerable<Feedback> GetAllApprovedFeedback()
        {
            return feedbackService.GetAllApprovedFeedback();
        }
        public bool UpdateStatus(int feedbackId, bool status)
        {
            return feedbackService.UpdateStatus(feedbackId, status);
        }
        public bool CreateFeedback(string userId, string additionalNotes, Boolean anonymous, Boolean allowed)
        {
            return feedbackService.CreateFeedback(userId, additionalNotes, anonymous, allowed);
        }
    }
}
