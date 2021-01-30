using MedbayTech.Rooms.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Rooms.Infrastructure.Database.Configurations
{
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {

            builder.ToTable("Hospital");
            builder.OwnsOne(a => a.Address).OwnsOne(a => a.City).OwnsOne(a => a.State);
            
        }
    
    }
}
