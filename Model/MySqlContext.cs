using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model.ExaminationSurgery;
using Model.Users;

namespace Model
{
    public class MySqlContext : DbContext
    {
        private DbSet<Treatment> Treatments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Treatment>().HasData(
                new Treatment { Id = 1, AdditionalNotes = "dada", Date = new DateTime(2020, 10, 31), Type = TreatmentType.hospitalTreatment }
            );

            modelBuilder.Entity<Feedback>().HasData(
                    new Feedback { Id = 1, AdditionalNotes = "dada", Date = new DateTime(2020, 10, 31), EverythingInGoodPlace = Grade.veryGood, Anonymous = true, Approved = true }
                );
        }
    }
}
