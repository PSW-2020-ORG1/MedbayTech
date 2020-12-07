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

        public List<Appointment> GetAllOtherAppointments(string id)
        {
            List<Appointment> allAppointments = _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
            List<Appointment> surveyableAppointments = GetSurveyableAppointments(id);
            List<Appointment> cancelableAppointments = GetCancelableAppointments(id);
            List<Appointment> allOtherAppointments = new List<Appointment>();

            allOtherAppointments = allAppointments.Where(p => !surveyableAppointments.Any(l => p.Id == l.Id)).ToList();
            allOtherAppointments = allOtherAppointments.Where(p => !cancelableAppointments.Any(l => p.Id == l.Id)).ToList();

            return allOtherAppointments;
        }

        public List<Appointment> GetAppointmentsByPatientId(string id)
        {
            return _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
        }

        public List<Appointment> GetCancelableAppointments(string id)
        {
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
            List<Appointment> cancelableAppointments = new List<Appointment>();
            cancelableAppointments = appointments.Where(p => p.Finished == false && ((p.Start - DateTime.Now).TotalDays > 2.00)).ToList();

            return cancelableAppointments;
        }

        public List<Appointment> GetSurveyableAppointments(string id)
        {
            List<Survey> surveys = _surveyRepository.GetAll().ToList();
            List<Appointment> appointments = _appointmentRepository.GetAppointmentsByPatientId(id).ToList();
            List<Appointment> surveyableAppointments = new List<Appointment>();
            surveyableAppointments = appointments.Where(p => !surveys.Any(l => p.Id == l.AppointmentId) && p.Finished == true).ToList();
            
            return surveyableAppointments;
        }

        public bool UpdateCanceled(int appointmentId)
        {
            Appointment appointment = _appointmentRepository.getAppointmentById(appointmentId);
            if (appointment == null) {
                return false;
            }
            if (appointment.CanceledByPatient)
            {
                return false;
            }
            appointment.CanceledByPatient = true;
            _appointmentRepository.Update(appointment);
            return true;


        }
    }
}