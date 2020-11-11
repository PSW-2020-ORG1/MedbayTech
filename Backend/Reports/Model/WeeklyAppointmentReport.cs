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
        public DateTime StartWeekDay { get; set; }
        public virtual List<Appointment> Appointments { get; set; }
        public WeeklyAppointmentReport() { }
        public WeeklyAppointmentReport(DateTime startWeekDay, List<Appointment> appointments, DateTime date, string content) : base(date, content)
        {
            StartWeekDay = startWeekDay;
            Appointments = appointments;
        }

       
    }
}