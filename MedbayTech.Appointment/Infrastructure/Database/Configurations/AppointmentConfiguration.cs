using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedbayTech.Appointment.Infrastructure.Database.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Domain.Entities.Appointment>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Appointment> builder)
        {
            builder.ToTable("Appointments");
            builder.Property(a => a.Id).HasColumnName("Id");

            builder.Property(a => a.CancelationDate).HasColumnName("CancelationDate");
            builder.Property(a => a.TypeOfAppointment).HasColumnName("TypeOfAppointment");
            builder.Property(a => a.ShortDescription).HasColumnName("ShortDescription");
            builder.Property(a => a.Urgent).HasColumnName("Urgent");
            builder.Property(a => a.Deleted).HasColumnName("Deleted");
            builder.Property(a => a.Finished).HasColumnName("Finished");
            builder.Property(a => a.CanceledByPatient).HasColumnName("CanceledByPatient");
            builder.Property(a => a.RoomId).HasColumnName("RoomId");
            builder.Property(a => a.DoctorId).HasColumnName("DoctorId");
            builder.Property(a => a.PatientId).HasColumnName("PatientId");

            builder.OwnsOne(a => a.Period);
        }
    }
}
