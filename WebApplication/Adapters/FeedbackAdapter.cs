using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Adapters
{
    public class FeedbackAdapter
    {
        public static List<ApprovedFeedbackDTO> ListApprovedFeedbackToListApprovedFeedbackDTO(List<Feedback> approvedFeedback)
        {
            List<ApprovedFeedbackDTO> approvedFeedbackList = new List<ApprovedFeedbackDTO>();
            foreach(Feedback feedbackIt in approvedFeedback) 
            {
                DateTime date = feedbackIt.Date;
                string additionalNotes = feedbackIt.AdditionalNotes;
                string name = "";
                string surname = "";
                if(feedbackIt.RegisteredUser != null)
                {
                    name = feedbackIt.RegisteredUser.Name;
                    surname = feedbackIt.RegisteredUser.Surname;
                }
                bool anonymous = feedbackIt.Anonymous;
                bool allowedForPublishing = feedbackIt.AllowedForPublishing;
                approvedFeedbackList.Add(new ApprovedFeedbackDTO(date, additionalNotes, name, surname, allowedForPublishing, anonymous));
            }

            return approvedFeedbackList;
               

        }
    }
}
