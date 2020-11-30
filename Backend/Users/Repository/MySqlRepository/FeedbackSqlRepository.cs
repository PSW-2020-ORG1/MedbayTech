using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Model.Users;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
    public class FeedbackSqlRepository : MySqlrepository<Feedback, int>,
        IFeedbackRepository
    {
        public FeedbackSqlRepository(MySqlContext context) : base(context) { }

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
                context.SaveChanges();
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
            return GetAll().ToList().Where(f => f.Approved & f.AllowedForPublishing);
        }

        /// <summary>
        /// Method for getting id of the last feedback entity in database
        /// </summary>
        /// <returns>integer id of the last entity in database</returns>
        public int GetLastId()
        {
            Feedback feedback = GetAll().Last();
            return feedback.Id;
        }

        public bool CheckIfExists(Feedback feedback)
        {
            return GetObject(feedback.Id) == null ? false : true;

        }
    }
}
