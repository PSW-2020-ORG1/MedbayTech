using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Database.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(p => p.Blocked).HasColumnName("Blocked");
            builder.Property(p => p.Token).HasColumnName("Token");
            builder.Property(p => p.Confirmed).HasColumnName("Confirmed");
            builder.Property(p => p.ShouldBeBlocked).HasColumnName("ShouldBeBlocked");
            builder.Property(p => p.IsGuestAccount).HasColumnName("IsGuestAccount");
            builder.Property(p => p.ChosenDoctorId).HasColumnName("ChosenDoctorId");

            builder.HasOne(p => p.ChosenDoctor);
        }
    }
}
