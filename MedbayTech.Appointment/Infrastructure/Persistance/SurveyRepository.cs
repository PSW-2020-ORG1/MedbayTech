using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Database;
using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Repository;

namespace MedbayTech.Appointment.Infrastructure.Persistance
{
    public class SurveyRepository : SqlRepository<Survey, int>, ISurveyRepository
    {
        public SurveyRepository(AppointmentDbContext context) : base(context) { }
    }
}
