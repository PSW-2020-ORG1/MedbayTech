﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MedbayTech.Repository.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Database
{
    public class UserDbContext : MyDbContext
    { 
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public UserDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public UserDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
