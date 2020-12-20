using Model.Users;
using System;
using System.Collections.Generic;

namespace Backend.Users.Service.Interfaces
{
    public interface IFeedbackService
    {
        List<Feedback> GetAll();
        List<Feedback> GetAllApprovedFeedback();
        bool UpdateStatus(int feedbackId, bool status);
        Feedback CreateFeedback(string userId, string additionalNotes, Boolean anonymous, Boolean allowed);
        Feedback CheckIfExists(Feedback feedback);
    }
}
