﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model.ExaminationSurgery;

namespace Repository
{
    public class MySQLContext : DbContext
    {
        private DbSet<Treatment> Treatments { get; set; }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Treatment>().HasData(
                new Treatment {Id = 1, AdditionalNotes = "dada", Date = new DateTime(2020, 10, 31), Type = TreatmentType.hospitalTreatment}
            );
        }
    }
}
