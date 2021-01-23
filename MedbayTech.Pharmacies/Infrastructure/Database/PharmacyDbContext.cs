using MedbayTech.Pharmacies.Domain.Entities.Pharmacies;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;
using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MedbayTech.Pharmacies.Infrastructure.Database
{
    public class PharmacyDbContext : MyDbContext
    {

        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<PharmacyNotification> PharmacyNotifications { get; set; }
        /*public DbSet<MedicationUsage> MedicationUsages { get; set; }*/
        /*public DbSet<MedicationUsageReport> MedicationUsageReports { get; set; }*/
        /*public DbSet<Medication> Medications { get; set; }*/
        public DbSet<UrgentMedicationProcurement> UrgentMedicationProcurements { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderOffer> TenderOffers { get; set; }
        public DbSet<TenderMedication> TenderMedications { get; set; }

        public PharmacyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public PharmacyDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
