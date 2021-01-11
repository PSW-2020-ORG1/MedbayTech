
using MedbayTech.Feedback.Domain.Events;

namespace MedbayTech.Feedback.Infrastructure.Persistance
{
    public class FeedbackEventRepository 
    {
        private readonly FeedbackDbContext _context;
        public FeedbackEventRepository(FeedbackDbContext context) 
        {
            _context = context;
        }

        public void Create(FeedbackEvent feedbackEvent)
        {
            _context.FeedbackEvents.Add(feedbackEvent);
            _context.SaveChanges();
        }
    }
}
