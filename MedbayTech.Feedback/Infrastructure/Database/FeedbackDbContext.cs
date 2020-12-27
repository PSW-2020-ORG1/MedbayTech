using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace MedbayTech.Feedback.Infrastructure.Persistance
{
    public class FeedbackDbContext : MyDbContext
    {
        public DbSet<Domain.Entities.Feedback> Feedbacks { get; set; }
        public FeedbackDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public FeedbackDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
