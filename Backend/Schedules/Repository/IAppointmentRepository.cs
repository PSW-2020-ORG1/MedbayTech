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
   public interface IAppointmentRepository : ICreate<Appointment>, IGet<Appointment, int>, IDelete<Appointment>, IGetAll<Appointment>, IUpdate<Appointment>
   {
        Dictionary<int, Appointment> GetAppointmentsBy(DateTime date);
        Dictionary<int, Appointment> GetScheduledFromToday();
        List<Appointment> GetCanceledAppointmentsByPatientId(string Id);
        IEnumerable<Appointment> GetAppointmentsByPatientId(string Id);
        IEnumerable<Appointment> GetBy(string doctorId, DateTime date);
    }
}