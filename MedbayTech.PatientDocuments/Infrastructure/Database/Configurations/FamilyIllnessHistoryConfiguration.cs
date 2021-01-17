using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Infrastructure.Database.Configurations
{
    public class FamilyIllnessHistoryConfiguration : IEntityTypeConfiguration<FamilyIllnessHistory>
    {
        public void Configure(EntityTypeBuilder<FamilyIllnessHistory> builder)
        {
            builder.ToTable("FamilyIllnessHistory");
            builder.HasMany(f => f.Diagnosis).WithOne().HasForeignKey(d => d.FamilyIllnessHistoryId);
        }
    }
}
