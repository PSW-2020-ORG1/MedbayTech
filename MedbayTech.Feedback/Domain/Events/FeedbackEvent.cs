using MedbayTech.Common.Domain.Events;

namespace MedbayTech.Feedback.Domain.Events
{
    public class FeedbackEvent : DomainEvent
    {
        public FeedbackEventType Type { get; set; }
        public virtual Entities.Feedback Feedback { get; set; }
        public int FeedbackId { get; set; }

        public FeedbackEvent() : base()
        {
        }

        public FeedbackEvent(FeedbackEventType type) : base()
        {
            Type = type;
        }
    }
}
