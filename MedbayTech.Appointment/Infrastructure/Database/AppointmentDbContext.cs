using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Appointment.Domain.Events;
using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Database
{
    public class AppointmentDbContext : MyDbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentEvent> AppointmentEvents { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }

        public DbSet<AppointmentRealocation> AppointmentRealocations { get; set; }
        public AppointmentDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public AppointmentDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}