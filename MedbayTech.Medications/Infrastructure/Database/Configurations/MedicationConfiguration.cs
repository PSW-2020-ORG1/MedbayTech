using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedbayTech.Medications.Infrastructure.Database.Configurations
{
    public class MedicationConfiguration : IEntityTypeConfiguration<Domain.Entities.Medications.Medication>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Medications.Medication> builder)
        {
            builder.ToTable("Medication");
            // builder.HasOne(m => m.MedicationCategory);
            builder.OwnsOne(m => m.MedicationCategory);
        }
    }
}
