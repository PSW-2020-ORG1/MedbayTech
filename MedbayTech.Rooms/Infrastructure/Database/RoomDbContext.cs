using MedbayTech.Repository.Infrastructure.Persistance;
using MedbayTech.Rooms.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MedbayTech.Rooms.Infrastructure.Database
{
    public class RoomDbContext : MyDbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<HospitalEquipment> HospitalEquipments { get; set; }


        public RoomDbContext() { }
        public RoomDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }

   
}
