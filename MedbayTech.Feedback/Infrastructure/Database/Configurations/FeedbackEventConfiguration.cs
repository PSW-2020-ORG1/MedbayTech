using MedbayTech.Feedback.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MedbayTech.Feedback.Infrastructure.Database.Configurations
{
    public class FeedbackEventConfiguration : IEntityTypeConfiguration<FeedbackEvent>
    {
        public void Configure(EntityTypeBuilder<FeedbackEvent> builder)
        {
            builder.ToTable("FeedbackEvents");
            builder.HasOne(f => f.Feedback);
        }
    }
}
