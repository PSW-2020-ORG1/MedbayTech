using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Database.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<MedbayTech.Appointment.Domain.Entities.Appointment>
    {
        public void Configure(EntityTypeBuilder<MedbayTech.Appointment.Domain.Entities.Appointment> builder)
        {
            builder.ToTable("Appointments");
            builder.Property(a => a.Id).HasColumnName("Id");
            //TODO add period
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
        }
    }
}
