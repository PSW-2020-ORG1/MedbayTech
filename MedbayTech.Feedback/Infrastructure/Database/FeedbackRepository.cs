using MedbayTech.Repository.Repository.SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Feedback.Infrastructure.Persistance;

namespace MedbayTech.Feedback.Infrastructure.Database
{
    public class FeedbackRepository : SqlRepository<Domain.Entities.Feedback, int>, 
        IFeedbackRepository
    {
        public FeedbackRepository(FeedbackDbContext context) : base(context) {}

        public bool UpdateStatus(int feedbackId, bool status)
        {
            if (ExistsBy(feedbackId))
            {
                Domain.Entities.Feedback feedback = GetBy(feedbackId);
                feedback.Approved = status;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Domain.Entities.Feedback> GetAllApprovedFeedback()
        {
            return GetAll().ToList().Where(f => f.Approved & f.AllowedForPublishing).ToList();
        }

        public bool CheckIfExists(Domain.Entities.Feedback feedback)
        {
            return GetBy(feedback.Id) == null ? false : true;
        }
    }
}
