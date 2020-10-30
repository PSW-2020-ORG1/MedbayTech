// File:    WeeklyAppointmentReport.cs
// Author:  Vlajkov
// Created: Thursday, May 28, 2020 9:13:55 PM
// Purpose: Definition of Class WeeklyAppointmentReport

using Model.Schedule;
using System;
using System.Collections.Generic;

namespace Model.Reports
{
   public class WeeklyAppointmentReport : Report
   {
        private DateTime startWeekDay;
        private List<Appointment> appointments;

        public WeeklyAppointmentReport(DateTime startDate, List<Appointment> appointments, DateTime date, string content) : base(date, content)
        {
            StartWeekDay = startDate;
            Appointments = appointments;
        }

        public DateTime StartWeekDay { get => startWeekDay; set => startWeekDay = value; }
        public List<Appointment> Appointments { get => appointments; set => appointments = value; }
    }
}