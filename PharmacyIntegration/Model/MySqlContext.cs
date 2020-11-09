using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyIntegration.Model
{
    public class MySqlContext : DbContext
    {
        public DbSet<Pharmacy> Pharmacies { get; set; }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>().HasData(
                new Pharmacy { Id = "Jankovic", APIKey = "ID1APIKEYAAAA" },
                new Pharmacy { Id = "Liman", APIKey = "ID2APIKEYAAAA" }
            );
        }

    }
}
