using Backend.Users.Model;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Users.Repository.MySqlRepository
{
    public class DoctorWorkDaySqlRepository : MySqlrepository<DoctorWorkDay, int>, IDoctorWorkDayRepository
    {
        public DoctorWorkDaySqlRepository(MedbayTechDbContext context) : base(context) { }
        public List<DoctorWorkDay> GetByDoctorId(string id)
        {
            return GetAll().Where(workDay => workDay.DoctorId.Equals(id)).ToList();
        }

        public DoctorWorkDay GetByDoctorIdAndDate(string id, DateTime date)
        {
            return GetAll().Where(workDay => workDay.DoctorId.Equals(id) && DateTime.Compare(workDay.Date, date) == 0).FirstOrDefault();
        }
    }
}
