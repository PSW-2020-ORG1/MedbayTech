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

        /// <summary>
        /// Function that changes the status of an existing feedback
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <param name="status"></param>
        /// <returns>boolean that shows if the status was changed or not</returns>
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

        /// <summary>
        /// Function that gets all feedback that is approved by the system administrator
        /// </summary>
        /// <returns>all feedback that is approved</returns>
        public IEnumerable<Feedback> GetAllApprovedFeedback()
        {
            return GetAll().Where(feedback => feedback.Approved == true && feedback.AllowedForPublishing);

        }
    }
}
