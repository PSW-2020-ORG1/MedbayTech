﻿using Model;
using Model.Schedule;
using Repository;
using Repository.ScheduleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Schedules.Repository.MySqlRepository
{
    public class AppointmentSqlRepository : MySqlrepository<Appointment, int>,
        IAppointmentRepository
    {
        public AppointmentSqlRepository(MySqlContext context) : base(context) { }
        public Dictionary<int, Appointment> GetAppointmentsBy(DateTime date)
        {
            return GetAll().ToList().Where(a => a.Period.StartTime.CompareTo(date) <= 0).ToDictionary(a => a.Id);
        }

        public List<Appointment> GetCanceledAppointmentsByPatientId(string id)
        {
            List<Appointment> appointments = GetAll().Where(a => a.CanceledByPatient).ToList();
            List<Appointment> appointments2 = GetAll().Where(a => a.PatientId.Equals(id)).ToList();
            appointments.Intersect(appointments2);
            return appointments;
        }

        public Dictionary<int, Appointment> GetScheduledFromToday()
        {
            return GetAll().ToList().Where(a => a.Period.StartTime.CompareTo(DateTime.Now) <= 0).ToDictionary(a => a.Id);
        }
    }
}
