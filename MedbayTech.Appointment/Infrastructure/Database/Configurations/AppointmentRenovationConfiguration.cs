using MedbayTech.Appointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Database.Configurations
{
    public class AppointmentRenovationConfiguration : IEntityTypeConfiguration<AppointmentRenovation>
    {
        public void Configure(EntityTypeBuilder<AppointmentRenovation> builder)
        {
            builder.OwnsOne(a => a.Period);
        }
    }
}
