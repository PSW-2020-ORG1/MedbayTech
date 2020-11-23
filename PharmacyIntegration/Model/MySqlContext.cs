using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyIntegration.Model
{
    public class MySqlContext : DbContext
    {
        public DbSet<Pharmacy> Pharmacies { get; set; }

        public DbSet<PharmacyNotification> PharmacyNotifications { get; set; }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>().HasData(
                new Pharmacy { Id = "Jankovic", APIKey = "ID1APIKEYAAAA", APIEndpoint = "jankovic.rs"},
                new Pharmacy { Id = "Liman", APIKey = "ID2APIKEYAAAA", APIEndpoint = "liman.li"}
            );
       
            modelBuilder.Entity<PharmacyNotification>().HasData(
                new PharmacyNotification { Id = 1, Content = "Aspirin nam je jeftin. Bas jako. Ide gaso!", Approved = true, PharmacyID = "Jankovic"},
                new PharmacyNotification { Id = 2, Content = "Brufen nam je jeftin. Bas jako. Ide gaso!", Approved = true, PharmacyID = "Liman"}
            );
        }

    }
}
