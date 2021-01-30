using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MedbayTech.PatientDocuments.Infrastructure.Database.Configurations
{
    public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.ToTable("Treatments");
            builder.HasOne(t => t.Report).WithMany().HasForeignKey(t => t.ReportId);
        }
    }
}
