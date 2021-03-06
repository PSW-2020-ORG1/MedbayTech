// File:    IAppointmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:52:12 AM
// Purpose: Definition of Interface IAppointmentRepository

using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Repository;
using System;
using System.Collections.Generic;

namespace Application.Common.Interfaces.Persistance
{
   public interface IAppointmentRepository : IRepository<Appointment, int>
   {
        Dictionary<int, Appointment> GetAppointmentsBy(DateTime date);
        Dictionary<int, Appointment> GetScheduledFromToday();
        List<Appointment> GetCanceledAppointmentsByPatient(string patientId);
        List<Appointment> GetAppointmentsByPatientId(string Id);
        List<Appointment> GetBy(string doctorId, DateTime date);
    }
}