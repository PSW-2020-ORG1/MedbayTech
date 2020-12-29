using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Infrastructure.Database.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");
            builder.HasMany(e => e.Treatments).WithOne().HasForeignKey(t => t.ReportId);
            builder.HasMany(e => e.Diagnoses).WithOne().HasForeignKey(d => d.ReportId);
        }
    }
}
