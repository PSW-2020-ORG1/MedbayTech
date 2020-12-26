using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Feedback.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedbayTech.Feedback.Infrastructure.Persistance.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Domain.Entities.Feedback>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Feedback> builder)
        {
            builder.ToTable("Feedbacks");
            builder.Property(f => f.Id).HasColumnName("Id");
            builder.Property(f => f.AdditionalNotes).HasColumnName("AdditionalNotes");
            builder.Property(f => f.UserId).HasColumnName("RegisteredUserId");
            builder.Property(f => f.AllowedForPublishing).HasColumnName("AllowedForPublishing");
            builder.Property(f => f.Anonymous).HasColumnName("Anonymous");
            builder.Property(f => f.Approved).HasColumnName("Approved");
            builder.Property(f => f.Date).HasColumnName("Date");

        }
    }
}
