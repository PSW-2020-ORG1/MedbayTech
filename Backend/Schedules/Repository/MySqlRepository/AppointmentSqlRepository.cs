using Model.Schedule;
using Repository;
using Repository.ScheduleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Schedules.Repository.MySqlRepository
{
    class AppointmentSqlRepository : MySqlrepository<Appointment, int>,
        IAppointmentRepository
    {
        public Dictionary<int, Appointment> GetAppointmentsBy(DateTime date)
        {
            return GetAll().ToList().Where(a => a.Period.StartTime.CompareTo(date) <= 0).ToDictionary(a => a.Id);
        }

        public Dictionary<int, Appointment> GetScheduledFromToday()
        {
            return GetAll().ToList().Where(a => a.Period.StartTime.CompareTo(DateTime.Now) <= 0).ToDictionary(a => a.Id);
        }
    }
}
