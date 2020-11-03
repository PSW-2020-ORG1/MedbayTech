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
        

    }
}
