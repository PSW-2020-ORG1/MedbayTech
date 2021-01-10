using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedbayTech.PatientDocuments.Infrastructure.Database.Configurations
{
    public class DiagnosisConfiguration : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder.ToTable("Diagnosis");
            builder.HasMany(d => d.Symptoms).WithOne().HasForeignKey(s => s.DiagnosisId);
        }
    }
}
