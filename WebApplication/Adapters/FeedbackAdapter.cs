using Model.Users;
using SimsProjekat.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Adapters
{
    public class FeedbackAdapter
    {
        /// <summary>
        /// Adapter method that transforms a list of approved feedback to the list of approved feedback dto
        /// </summary>
        /// <param name="approvedFeedback"></param>
        /// <returns>list of approved feedback dto that contains date, additional notes, name, surname, anonymous status and allowed for publishing status</returns>
      public static List<ApprovedFeedbackDTO> ListApprovedFeedbackToListApprovedFeedbackDTO(List<Feedback> approvedFeedback)
        {
            List<ApprovedFeedbackDTO> approvedFeedbackList = new List<ApprovedFeedbackDTO>();
            foreach (Feedback feedbackIt in approvedFeedback)
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
        /// <summary>
        /// Adapter method that transforms a list of all feedback to the list of all feedback dto
        /// </summary>
        /// <param name="allFeedback"></param>
        /// <returns>list of feedback dto that contains id, date, additional notes, name, surname, approved status, anonymous status and allowed for publishing status</returns>
        public static List<AllFeedbackDTO> ListAllFeedbackToListAllFeedbackDTO(List<Feedback> allFeedback)
        {
            List<AllFeedbackDTO> allFeedbackList = new List<AllFeedbackDTO>();
            foreach (Feedback feedbackIt in allFeedback)
            {
                int id = feedbackIt.Id;
                DateTime date = feedbackIt.Date;
                string additionalNotes = feedbackIt.AdditionalNotes;
                string name = "";
                string surname = "";
                if (feedbackIt.RegisteredUser != null)
                {
                    name = feedbackIt.RegisteredUser.Name;
                    surname = feedbackIt.RegisteredUser.Surname;
                }
                Boolean approved = feedbackIt.Approved;
                Boolean anonymous = feedbackIt.Anonymous;
                Boolean allowedForPublishing = feedbackIt.AllowedForPublishing;
                allFeedbackList.Add(new AllFeedbackDTO(id, date, additionalNotes, name, surname, approved, anonymous, allowedForPublishing));
            }

            return allFeedbackList;
        }
    }
}