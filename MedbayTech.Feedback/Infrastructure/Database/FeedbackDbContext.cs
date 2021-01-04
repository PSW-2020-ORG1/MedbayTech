using MedbayTech.Feedback.Domain.Events;
using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MedbayTech.Feedback.Infrastructure.Persistance
{
    public class FeedbackDbContext : MyDbContext
    {
        public DbSet<Domain.Entities.Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackEvent> FeedbackEvents { get; set; }
        public FeedbackDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public FeedbackDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
