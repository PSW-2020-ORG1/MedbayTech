using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service.Interfaces
{
    public interface IFeedbackService
    {
        IEnumerable<Feedback> GetAll();
        IEnumerable<Feedback> GetAllApprovedFeedback();
        bool UpdateStatus(int feedbackId, bool status);
        Feedback CreateFeedback(string userId, string additionalNotes, Boolean anonymous, Boolean allowed);
        Feedback CheckIfExists(Feedback feedback);
    }
}
