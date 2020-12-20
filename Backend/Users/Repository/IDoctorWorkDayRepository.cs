using Backend.Users.Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Backend.Users.Repository
{
    public interface IDoctorWorkDayRepository : IRepository<DoctorWorkDay, int>
    {
        List<DoctorWorkDay> GetByDoctorId(string id);
        public DoctorWorkDay GetByDoctorIdAndDate(string id, DateTime date);
    }
}
