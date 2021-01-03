using MedbayTech.Rooms.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Rooms.Infrastructure.Database.Configurations
{
    public class DepartmentConfigurationc : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.ToTable("Department");
            builder.OwnsOne(a => a.Hospital).OwnsOne(a => a.Address).OwnsOne(a => a.City).OwnsOne(a => a.State);
        }
    }
}
