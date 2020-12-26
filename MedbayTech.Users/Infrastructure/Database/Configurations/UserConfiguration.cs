using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<RegisteredUser>
    {
        public void Configure(EntityTypeBuilder<RegisteredUser> builder)
        {
            builder.ToTable("RegisteredUsers");
            builder.Property(ru => ru.Id).HasColumnName("Id");
            builder.Property(ru => ru.Name).HasColumnName("Name");
            builder.Property(ru => ru.Surname).HasColumnName("Surname");
            builder.Property(ru => ru.CurrResidenceId).HasColumnName("CurrResidenceId");
            builder.Property(ru => ru.DateOfBirth).HasColumnName("DateOfBirth");
            builder.Property(ru => ru.DateOfCreation).HasColumnName("DateOfCreation");
            builder.Property(ru => ru.Email).HasColumnName("Email");
            builder.Property(ru => ru.Username).HasColumnName("Username");
            builder.Property(ru => ru.Password).HasColumnName("Password");
            builder.Property(ru => ru.EducationLevel).HasColumnName("EducationLevel");
            builder.Property(ru => ru.Gender).HasColumnName("Gender");
            builder.Property(ru => ru.InsurancePolicyId).HasColumnName("InsurancePolicyId");
            builder.Property(ru => ru.Phone).HasColumnName("Phone");
            builder.Property(ru => ru.PlaceOfBirthId).HasColumnName("PlaceOfBirthId");
            builder.Property(ru => ru.Profession).HasColumnName("Profession");
            builder.Property(ru => ru.ProfileImage).HasColumnName("ProfileImage");
            

        }
    }
}
