// File:    IAppointmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:52:12 AM
// Purpose: Definition of Interface IAppointmentRepository

using Model.Schedule;
using Model.Users;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Repository.ScheduleRepository
{
   public interface IAppointmentRepository : IRepository<Appointment,int>
   {
        Dictionary<int, Appointment> GetAppointmentsBy(DateTime date);
        Dictionary<int, Appointment> GetScheduledFromToday();
    }
}