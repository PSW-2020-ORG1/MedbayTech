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
        /// <summary>
        /// Feedback service method for getting all feedback
        /// </summary>
        /// <returns>feedback objects</returns>
        public IEnumerable<Feedback> GetAll()
        {
            return unitOfWork.FeedBackRepository.GetAll();
        }
        /// <summary>
        /// Feedback service method for getting all feedback that is approved by the system administrator
        /// </summary>
        /// <returns>approved feedback objects</returns>
        public IEnumerable<Feedback> GetAllApprovedFeedback()
        {
            return unitOfWork.FeedBackRepository.GetAllApprovedFeedback();
        }
        /// <summary>
        /// Feedback service method for updating the status of a feedback
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <param name="status"></param>
        /// <returns>boolean</returns>
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
