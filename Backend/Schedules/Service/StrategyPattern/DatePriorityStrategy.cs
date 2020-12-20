// File:    DatePriorityStrategy.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 1:09:09 AM
// Purpose: Definition of Class DatePriorityStrategy

using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Rooms.Service;
using Backend.Schedules.Service.Interfaces;
using Model.Users;

namespace Service.ScheduleService
{
    public class DatePriorityStrategy : IPriorityStrategy
    {
        private IAppointmentService _appointmentService;
        private IDoctorService _doctorService;

        private const int NUMBER_OF_RECOMMENDED_APPOINTMENTS = 5;
        public DatePriorityStrategy(IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        public List<Appointment> Recommend(PriorityParameters parameters)
        {
            List<Appointment> recommendedAppointments = new List<Appointment>();
            List<Doctor> doctors = GetDoctorsBy(parameters.SpecializationId);

            recommendedAppointments = RecommendationResult(doctors, parameters);

            return recommendedAppointments;
        }

        public List<Appointment> RecommendationResult(List<Doctor> doctors, PriorityParameters parameters)
        {
            List<Appointment> result = new List<Appointment>();
            foreach (Doctor doctorIt in doctors)
            {
                parameters.DoctorId = doctorIt.Id;
                List<Appointment> appointments = _appointmentService.GetAvailableByDoctorAndDateRange(parameters);
                result.AddRange(appointments);
                if (result.Count >= NUMBER_OF_RECOMMENDED_APPOINTMENTS)
                    return result.Where(ap => result.IndexOf(ap) < NUMBER_OF_RECOMMENDED_APPOINTMENTS).ToList();
            }

            return result;
        }
        public List<Appointment> GetAvailable(string doctorId, DateTime startDate, DateTime endDate)
        {

            List<Appointment> availableAppointments = new List<Appointment>();
            while(startDate.AddDays(1) <= endDate)
            {
                availableAppointments.AddRange(_appointmentService.GetAvailableBy(doctorId, startDate));
            }

            return availableAppointments;
        }
        public List<Doctor> GetDoctorsBy(int specializationId)
        {
            return _doctorService.GetDoctorsBy(specializationId).ToList();
        }
    }
}