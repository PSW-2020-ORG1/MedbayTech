using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Feedback.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedbayTech.Feedback.Infrastructure.Persistance.Configurations
{
    /*public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("RegisteredUsers");
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Name).HasColumnName("Name");
            builder.Property(u => u.Surname).HasColumnName("Surname");

            builder.HasOne<User>().WithOne().HasForeignKey<User>(u => u.Id);
        }
    }*/
}
