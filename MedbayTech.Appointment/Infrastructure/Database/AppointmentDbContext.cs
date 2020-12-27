using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class AppointmentDbContext : MyDbContext<MedbayTech.Appointment.Domain.Entities.Appointment, int>
    {
        public DbSet<MedbayTech.Appointment.Domain.Entities.Appointment> Appointments { get; set; }
        public AppointmentDbContext(DbContextOptions<MyDbContext<MedbayTech.Appointment.Domain.Entities.Appointment, int>> options) : base(options) { }
        public AppointmentDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}