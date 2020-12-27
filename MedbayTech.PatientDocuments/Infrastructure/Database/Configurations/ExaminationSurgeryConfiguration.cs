using Backend.Examinations.Model;
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
            builder.HasMany(e => e.Treatments);
            builder.HasMany(e => e.Diagnoses);
        }
    }
}
