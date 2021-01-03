using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Database
{
    public class AppointmentDbContext : MyDbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public AppointmentDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public AppointmentDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}