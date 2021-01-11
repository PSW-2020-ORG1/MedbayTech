using MedbayTech.Medications.Domain.Entities.Reports;
using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MedbayTech.Medications.Infrastructure.Database
{
    public class MedicationDbContext : MyDbContext
    {
        public DbSet<MedicationUsage> MedicationUsages { get; set; }
        public DbSet<MedicationUsageReport> MedicationUsageReports { get; set; }
        public DbSet<Domain.Entities.Medications.Medication> Medications { get; set; }
        public MedicationDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public MedicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
