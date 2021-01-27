using MedbayTech.Appointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Database.Configurations
{
    public class AppointmentRealocationConfiguration : IEntityTypeConfiguration<AppointmentRealocation>
    {
        public void Configure(EntityTypeBuilder<AppointmentRealocation> builder)
        {
            builder.OwnsOne(a => a.Period);
        }
    }
}
