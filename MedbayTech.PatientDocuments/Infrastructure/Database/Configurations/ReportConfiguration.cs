using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedbayTech.PatientDocuments.Infrastructure.Database.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");
            builder.HasMany(e => e.Treatments).WithOne().HasForeignKey(t => t.ReportId);
            builder.HasMany(e => e.Diagnoses).WithOne().HasForeignKey(d => d.ReportId);
            builder.HasOne(e => e.MedicalRecord).WithMany().HasForeignKey(m => m.MedicalRecordId);

        }
    }
}
