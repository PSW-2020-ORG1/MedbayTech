using MedbayTech.Repository;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using MedbayTech.Users.Domain.Entites;

namespace MedbayTech.Users.Infrastructure.Persistance
{
    public class WorkDayRepository : SqlRepository<WorkDay, int>, IWorkDayRepository
    {
        public WorkDayRepository(UserDbContext context) : base(context) { }

        public List<WorkDay> GetByDoctorId(string id)
        {
            return GetAll().Where(workDay => workDay.DoctorId.Equals(id)).ToList();
        }

        public WorkDay GetByDoctorIdAndDate(string id, DateTime date)
        {
            return GetAll().Where(workDay => workDay.DoctorId.Equals(id) && DateTime.Compare(workDay.Date, date) == 0).FirstOrDefault();
        }
    }
}
