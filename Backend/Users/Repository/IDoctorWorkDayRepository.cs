using Backend.Users.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository
{
    public interface IDoctorWorkDayRepository : IRepository<DoctorWorkDay, int>
    {
        IEnumerable<DoctorWorkDay> GetByDoctorId(string id);
        public DoctorWorkDay GetByDoctorIdAndDate(string id, DateTime date);
    }
}
