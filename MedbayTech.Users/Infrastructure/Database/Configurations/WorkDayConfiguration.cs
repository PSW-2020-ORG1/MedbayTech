using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Domain.Entites;

namespace MedbayTech.Users.Infrastructure.Database.Configurations
{
    public class WorkDayConfiguration : IEntityTypeConfiguration<WorkDay>
    {

        public void Configure(EntityTypeBuilder<WorkDay> builder)
        {
            builder.ToTable("WorkDay");
            builder.HasOne(e => e.Doctor);

        }
    }
    
}
