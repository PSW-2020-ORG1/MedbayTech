using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedbayTech.Users.Domain.Entites;

namespace MedbayTech.Users.Infrastructure.Database.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {

        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasOne(doc => doc.Specialization);
        }
    }
}
