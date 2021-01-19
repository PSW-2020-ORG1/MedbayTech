using MedbayTech.Repository.Infrastructure.Persistance;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MedbayTech.Tenders.Infrastructure.Database
{
    public class TenderDbContext : MyDbContext
    {
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderOffer> TenderOffers { get; set; }
        public DbSet<TenderMedication> TenderMedications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
