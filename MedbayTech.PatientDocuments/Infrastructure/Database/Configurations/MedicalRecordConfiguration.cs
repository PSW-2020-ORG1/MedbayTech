using Backend.Records.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Infrastructure.Database.Configurations
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.ToTable("MedicalRecords");
            builder.OwnsMany(m => m.Allergies);
            builder.HasMany(m => m.FamilyIllnessHistory);
            builder.OwnsMany(m => m.Vaccines);
            builder.OwnsMany(m => m.Therapies);
            builder.HasMany(m => m.IllnessHistory);
        }
    }
}
