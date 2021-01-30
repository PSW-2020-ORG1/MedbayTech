using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Feedback.Infrastructure.Services
{
    public interface IFeedbackService
    {
        List<Domain.Entities.Feedback> GetAll();
        List<Domain.Entities.Feedback> GetAllApprovedFeedback();
        bool UpdateStatus(int feedbackId, bool status);
        Domain.Entities.Feedback CreateFeedback(string userId, string additionalNotes, Boolean anonymous, Boolean allowed);
        Domain.Entities.Feedback CheckIfExists(Domain.Entities.Feedback feedback);
    }
}
