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

        public IEnumerable<Feedback> GetAllApprovedFeedback()
        {
            return GetAll().Where(feedback => feedback.Approved == true);

        }
    }
}
