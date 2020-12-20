// File:    IAppointmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:52:12 AM
// Purpose: Definition of Interface IAppointmentRepository

using Model.Schedule;
using System;
using System.Collections.Generic;

namespace Repository.ScheduleRepository
{
   public interface IAppointmentRepository : ICreate<Appointment>, IGet<Appointment, int>, IDelete<Appointment>, IGetAll<Appointment>, IUpdate<Appointment>
   {
        Dictionary<int, Appointment> GetAppointmentsBy(DateTime date);
        Dictionary<int, Appointment> GetScheduledFromToday();
        List<Appointment> GetCanceledAppointments();
        List<Appointment> GetAppointmentsByPatientId(string Id);
        List<Appointment> GetBy(string doctorId, DateTime date);
    }
}