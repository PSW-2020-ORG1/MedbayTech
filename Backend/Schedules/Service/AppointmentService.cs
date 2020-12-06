/***********************************************************************
 * Module:  AppointmentService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.AppointmentService
 ***********************************************************************/

using Backend.Records.Model;
using Model.Rooms;
using Model.Schedule;
using Model.Users;
using Repository.ScheduleRepository;
using Service.GeneralService;
using Service.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Exceptions.Schedules;
using Backend.Schedules.Service.Interfaces;

namespace Service.ScheduleService
{
   public class AppointmentService : IAppointmentService
   {
        IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {      
            _appointmentRepository = appointmentRepository;       
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsByPatientId(string id)
        {
            return _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
        }
    }
}