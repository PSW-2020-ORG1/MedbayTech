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

        public bool CheckIfExistsById(int id)
        {
            foreach (Survey s in GetAll())
            {
                if (s.AppointmentId == id)
                {
                    return false;
                }
            }
            return true;
        }

        public int GetLastId()
        {
            int id;
            if (GetAll() == null)
            {
                id = 1;
            }
            else
            {
                Survey survey = GetAll().Last();
                id = survey.Id;
            }
            return id;
        }
    }
}
