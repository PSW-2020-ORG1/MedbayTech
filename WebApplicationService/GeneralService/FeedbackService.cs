using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Model.Users;
using Repository;

namespace WebApplicationService.GeneralService
{
    public class FeedbackService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<Feedback> GetAll()
        {
            return unitOfWork.FeedBackRepository.GetAll();
        }

        public IEnumerable<Feedback> GetAllApprovedFeedback()
        {
            return unitOfWork.FeedBackRepository.GetAllApprovedFeedback();
        }

        public bool UpdateStatus(int feedbackId, bool status)
        {
            bool statusUpdated = unitOfWork.FeedBackRepository.UpdateStatus(feedbackId, status);
            if (statusUpdated)
            {
                unitOfWork.Save();
            }

            return statusUpdated;
        }

        public bool CreateFeedback(string userId, string additionalNotes, Boolean anonymous, Boolean allowed)
        {

            int feedbackId = GenerateFeedbackId();
            Feedback feedback = new Feedback();
            feedback.Id = feedbackId;
            feedback.AdditionalNotes = additionalNotes;
            feedback.Anonymous = anonymous;
            feedback.AllowedForPublishing = allowed;
            if (!anonymous)
            {
                feedback.RegisteredUserId = userId;
            }

            Feedback createdFeedback = unitOfWork.FeedBackRepository.Create(feedback);
            if(createdFeedback == null)
            {
                return false;
            }
            unitOfWork.Save();
            return true;

        }

        public int GenerateFeedbackId()
        {
            int id;
            id = unitOfWork.FeedBackRepository.GetLastId();
            return ++id;
        }



    }
}
