using MedbayTech.Repository.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace MedbayTech.Repository.Infrastructure.Persistance
{
    public class MyDbContext<T, ID> : DbContext
        where T : class, IIdentifiable<ID>
        where ID : IComparable
    {
        public MyDbContext(DbContextOptions<MyDbContext<T, ID>> options) : base(options) { }

        public MyDbContext() {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (IsPostgres())
            {
                optionsBuilder.UseNpgsql(CreateConnectionStringFromEnvironmentPostgres());
                optionsBuilder.UseLazyLoadingProxies(true);
            }
            else
            {
                optionsBuilder.UseMySql(CreateConnectionStringFromEnvironment());
                optionsBuilder.UseLazyLoadingProxies(true);
            }
        }

        public string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "newdb25";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";

            return $"server={server};port={port};database={database};user={user};password={password}";
        }

        public string CreateConnectionStringFromEnvironmentPostgres()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "newdb";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";

            return $"Server={server};Port={port};Database={database};User Id={user};Password={password}";
        }

        public bool IsPostgres()
        {
            string host = Environment.GetEnvironmentVariable("DATABASE_TYPE") ?? "localhost";
            return host.Equals("postgres");
        }
    }
}
