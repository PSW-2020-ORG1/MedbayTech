using Backend.Examinations.Model;
using Backend.Records.Model;
using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Infrastructure.Database
{
    public class PatientDocumentsDbContext : MyDbContext
    {
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<FamilyIllnessHistory> FamilyIllnessHistory { get; set; }
        public DbSet<ExaminationSurgery> ExaminationSurgeries { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public PatientDocumentsDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public PatientDocumentsDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
