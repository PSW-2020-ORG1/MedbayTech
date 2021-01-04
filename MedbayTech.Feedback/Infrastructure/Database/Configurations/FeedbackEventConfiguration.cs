using MedbayTech.Feedback.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Feedback.Infrastructure.Database.Configurations
{
    public class FeedbackEventConfiguration : IEntityTypeConfiguration<FeedbackEvent>
    {
        public void Configure(EntityTypeBuilder<FeedbackEvent> builder)
        {
            builder.ToTable("FeedbackEvents");
            builder.HasOne(f => f.Feedback).WithOne().HasForeignKey("Feedback", "FeedbackId");
        }
    }
}
