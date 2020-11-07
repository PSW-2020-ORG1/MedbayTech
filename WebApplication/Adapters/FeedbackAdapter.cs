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
      public static List<ApprovedFeedbackDTO> ListApprovedFeedbackToListApprovedFeedbackDTO(List<Feedback> approvedFeedback)
        {
            List<ApprovedFeedbackDTO> approvedFeedbackList = new List<ApprovedFeedbackDTO>();
            foreach(Feedback feedbackIt in approvedFeedback) 
            {
                DateTime date = feedbackIt.Date;
                string additionalNotes = feedbackIt.AdditionalNotes;
                string username = feedbackIt.RegisteredUser.Username;
                approvedFeedbackList.Add(new ApprovedFeedbackDTO(date, additionalNotes, username));
            }

            return approvedFeedbackList;
               

        } 

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
