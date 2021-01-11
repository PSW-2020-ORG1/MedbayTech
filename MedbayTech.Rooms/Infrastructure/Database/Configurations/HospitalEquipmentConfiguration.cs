using MedbayTech.Rooms.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedbayTech.Rooms.Infrastructure.Database.Configurations
{
    public class HospitalEquipmentConfiguration : IEntityTypeConfiguration<HospitalEquipment>
    {
        public void Configure(EntityTypeBuilder<HospitalEquipment> builder)
        {

            builder.ToTable("HospitalEquipment");

            builder.HasOne(r => r.Room).WithMany().HasForeignKey(h => h.RoomId);
            builder.HasOne(e => e.EquipmentType).WithMany().HasForeignKey(h => h.EquipmentTypeId);
        }

    }
}
