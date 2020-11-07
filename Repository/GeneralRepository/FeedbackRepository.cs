using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Model.Users;

namespace Repository.GeneralRepository
{
    public class FeedbackRepository : MySqlrepository<Feedback, int>
    {
        public FeedbackRepository(MySqlContext context) : base(context) { }

        /// <summary>This method changes the status of a feedback to approved or denied, depending on what the system administrator selected</summary>
        public bool UpdateStatus(int feedbackId, bool status)
        {
            if (ExistsInSystem(feedbackId))
            {
                Feedback feedback = GetObject(feedbackId);
                feedback.Approved = status;
                return true;
            }

            
            return false;
        }

        /// <summary>This method returns all feedback that is approved to be published by the system administrator</summary>
        public IEnumerable<Feedback> GetAllApprovedFeedback()
        {
            return GetAll().Where(feedback => feedback.Approved == true && feedback.AllowedForPublishing);

        }
    }
}
