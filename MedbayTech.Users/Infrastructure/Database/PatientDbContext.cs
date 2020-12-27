using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Database
{
    public class PatientDbContext : MyDbContext<Patient, string>
    {
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public PatientDbContext(DbContextOptions<MyDbContext<Patient, string>> options) : base(options) { }
        public PatientDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
