using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Appointment.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Database.Configurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Domain.Entities.Survey>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Survey> builder)
        {
            builder
                .Property(b => b.SurveyQuestions)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<int>>(v)
            );
            builder
                .Property(b => b.SurveyAnswers)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<Grade>>(v)
                    );
        }
    }
}
