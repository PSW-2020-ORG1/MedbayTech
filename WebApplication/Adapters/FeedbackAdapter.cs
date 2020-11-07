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
            foreach (Feedback feedbackIt in approvedFeedback)
            {
                DateTime date = feedbackIt.Date;
                string additionalNotes = feedbackIt.AdditionalNotes;
                string username = feedbackIt.RegisteredUser.Username;
                approvedFeedbackList.Add(new ApprovedFeedbackDTO(date, additionalNotes, username));
            }

            return approvedFeedbackList;


        }

    }
}