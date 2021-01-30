using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedbayTech.PatientDocuments.Infrastructure.Database.Configurations
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.ToTable("MedicalRecords");
            builder.HasMany(m => m.Allergens).WithOne().HasForeignKey(a => a.MedicalRecordId);
            builder.HasMany(m => m.FamilyIllnessHistory).WithOne();
            builder.HasMany(m => m.Vaccines).WithOne().HasForeignKey(v => v.MedicalRecordId);
            builder.HasMany(m => m.Therapies).WithOne().HasForeignKey(t => t.MedicalRecordId);
            builder.HasMany(m => m.IllnessHistory).WithOne();
        }
    }
}
