using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Infrastructure.Database.Configurations
{
    public class ExaminationSurgeryConfiguration : IEntityTypeConfiguration<ExaminationSurgery>
    {
        public void Configure(EntityTypeBuilder<ExaminationSurgery> builder)
        {
            builder.ToTable("ExaminationSurgery");
            builder.HasMany(e => e.Treatments).WithOne().HasForeignKey(t => t.ExaminationSurgeryId);
            builder.HasMany(e => e.Diagnoses).WithOne().HasForeignKey(d => d.ExaminationSurgeryId);
        }
    }
}
