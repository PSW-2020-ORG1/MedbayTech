using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
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
        public DbSet<Report> Reports { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Allergens> Allergens { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
        public DbSet<Symptoms> Symptoms { get; set; }
        public DbSet<Vaccines> Vaccines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public PatientDocumentsDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public PatientDocumentsDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
