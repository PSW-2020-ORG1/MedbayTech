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
    public class UserDbContext : MyDbContext<RegisteredUser, string>
    {
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public UserDbContext(DbContextOptions<MyDbContext<RegisteredUser, string>> options) : base(options) { }
        public UserDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
