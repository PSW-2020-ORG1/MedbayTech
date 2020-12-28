﻿using Backend.Records.Model;
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
            builder.HasMany(m => m.Allergies).WithOne();
            builder.HasMany(m => m.FamilyIllnessHistory).WithOne();
            builder.HasMany(m => m.Vaccines).WithOne();
            builder.HasMany(m => m.Therapies).WithOne();
            builder.HasMany(m => m.IllnessHistory).WithOne();
        }
    }
}
