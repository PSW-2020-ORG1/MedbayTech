using MedbayTech.Appointment.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MedbayTech.Appointment.Infrastructure.Database.Configurations
{
    public class AppointmentEventConficuration : IEntityTypeConfiguration<AppointmentEvent>
    {
        public void Configure(EntityTypeBuilder<AppointmentEvent> builder)
        {
            builder.ToTable("AppointmentEvents");
            builder.HasOne(a => a.Appointment);
        }
    }
}
