// File:    DoctorPriorityStrategy.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 1:09:09 AM
// Purpose: Definition of Class DoctorPriorityStrategy

using Model.Schedule;
using Model.Users;
using Backend.General.Model.ScheduleRepository;
using System;
using System.Collections.Generic;
using Backend.Exceptions.Schedules;
using Backend.Utils;

namespace Service.ScheduleService
{
   public class DoctorPriorityStrategy : IPriorityStrategy
   {
        public Appointment Recommend(PriorityParameters parameters)
        {
            Period period = parameters.SetStartTime(startWorkingHours, endWorkingHours);

            List<Appointment> allAppointmentsInTimePeriod = new List<Appointment>();
            while (period.StartTime.Date.CompareTo(parameters.ChosenEndDate) < 0)
            {
                var appointmentsForDoctors = appointmentService.AvailableExaminationsFor(parameters.ChosenDoctor, period.StartTime, false);
                allAppointmentsInTimePeriod.AddRange(appointmentsForDoctors.Values);
                period.AddDay();
            }
            return RecommendResults(allAppointmentsInTimePeriod, parameters);
        }

        public Appointment RecommendResults(List<Appointment> allAppointmentsInTimePeriod, PriorityParameters parameters)
        {
            if (allAppointmentsInTimePeriod.Count > 0)
                return allAppointmentsInTimePeriod[rndGen.Next(0, allAppointmentsInTimePeriod.Count)];
            return RecommendAfterDate(parameters);   
        }

        private Appointment RecommendAfterDate(PriorityParameters parameters)
        {
            DateTime startFrom = parameters.ChosenEndDate.Date.AddDays(1);
            List<Appointment> allAppointmentsInTimePeriod = new List<Appointment>();

            var appointmentsForDoctors = appointmentService.AvailableExaminationsFor(parameters.ChosenDoctor, startFrom, false);
            foreach (Appointment appointment in appointmentsForDoctors.Values)
                return appointment;
            throw  new NoAppointmentsFound();
        }

        public DoctorPriorityStrategy(AvailableAppointmentService appointmentService, int startHours, int endHours)
        {
            startWorkingHours = startHours;
            endWorkingHours = endHours;
            rndGen = new Random();
            this.appointmentService = appointmentService;
        }

        private readonly int startWorkingHours;
        private readonly int endWorkingHours;
        private readonly Random rndGen;

        public AvailableAppointmentService appointmentService;
   
   }
}