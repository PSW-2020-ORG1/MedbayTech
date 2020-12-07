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
using Backend.Users.Repository.MySqlRepository;

namespace Service.ScheduleService
{
   public class AppointmentService : IAppointmentService
   {
        IAppointmentRepository _appointmentRepository;
        ISurveyRepository _surveyRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository, ISurveyRepository surveyRepository)
        {      
            _appointmentRepository = appointmentRepository;
            _surveyRepository = surveyRepository;
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsByPatientId(string id)
        {
            return _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
        }

        public List<Appointment> GetSurveyableAppointments(string id)
        {
            List<Survey> surveys = _surveyRepository.GetAll().ToList();
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
            List<Appointment> surveyableAppointments = new List<Appointment>();
            foreach (Appointment a in appointments)
            {
                if (!(surveys.Count == 0))
                {
                    foreach (Survey s in surveys)
                    {
                        if (a.Id != s.AppointmentId && a.Finished == true)
                        {
                            surveyableAppointments.Add(a);
                            break;
                        }
                    }
                }
                else 
                {
                    if (a.Finished == true) 
                    {
                        surveyableAppointments.Add(a);
                    }
                }
            }
            return surveyableAppointments;
            
        }
    }
}