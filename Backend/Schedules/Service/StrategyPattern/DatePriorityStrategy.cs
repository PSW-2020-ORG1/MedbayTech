// File:    DatePriorityStrategy.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 1:09:09 AM
// Purpose: Definition of Class DatePriorityStrategy

using Model.Schedule;
using Backend.General.Model.ScheduleRepository;
using System;
using System.Collections.Generic;
using Backend.Utils;

namespace Service.ScheduleService
{
   public class DatePriorityStrategy : IPriorityStrategy
   {
        public Appointment Recommend(PriorityParameters parameters)
        {
            Period period = parameters.SetStartTime(startWorkingHours, endWorkingHours);
            List<Appointment> allAppointmentsInTimePeriod = new List<Appointment>();
            while (period.IsPeriodActive())
            {
                var appointmentsForDoctors = appointmentService.AvailableExaminationsFor(parameters.ChosenDoctor, period.StartTime.Date, false);
                allAppointmentsInTimePeriod.AddRange(appointmentsForDoctors.Values);
                period.AddDay();
            }
            return RecommendResults(allAppointmentsInTimePeriod, parameters);
        }

        public Appointment RecommendResults(List<Appointment> allAppointmentsInTimePeriod, PriorityParameters parameters)
        {
            if (allAppointmentsInTimePeriod.Count > 0)
                return RecommendBest(allAppointmentsInTimePeriod, parameters);
            return FindAnyOtherAppointment(parameters);
        }

        private Appointment FindAnyOtherAppointment(PriorityParameters parameters)
        {
            Period period = parameters.SetStartTime(startWorkingHours, endWorkingHours);
            List<Appointment> allAppointmentsInTimePeriod = new List<Appointment>();
            while (period.IsPeriodActive())
            {
                var appointmentsForDoctors = appointmentService.ScheduleAppointments(period.StartTime, TypeOfAppointment.Examination);
                allAppointmentsInTimePeriod.AddRange(appointmentsForDoctors.Values);
                period.AddDay();
            }
            return RecommendAnyOtherResults(allAppointmentsInTimePeriod, parameters);
        }

        private Appointment RecommendAnyOtherResults(List<Appointment> allAppointmentsInTimePeriod, PriorityParameters parameters)
        {
            DateTime minimumDate = parameters.ChosenEndDate.Date;
            Appointment bestAppointment = null;
            foreach (Appointment appointment in allAppointmentsInTimePeriod)
            {
                if (appointment.Period.StartTime.CompareTo(minimumDate) < 0)
                {
                    minimumDate = appointment.Period.StartTime;
                    bestAppointment = appointment;
                }
            }
            return bestAppointment;
        }

        private Appointment RecommendBest(List<Appointment> allAppointmentsInTimePeriod, PriorityParameters parameters)
        {
            DateTime minimumDate = parameters.ChosenEndDate.Date;
            Appointment bestAppointment = null;
            foreach (Appointment appointment in allAppointmentsInTimePeriod)
            {
                if (appointment.Period.StartTime.CompareTo(minimumDate) < 0)
                {
                    minimumDate = appointment.Period.StartTime;
                    bestAppointment = appointment;
                }
            }
            return bestAppointment;
        }

        public DatePriorityStrategy(AvailableAppointmentService appointmentService, int startHours, int endHours)
        {
            startWorkingHours = startHours;
            endWorkingHours = endHours;
            this.appointmentService = appointmentService;
        }


        private readonly int startWorkingHours;
        private readonly int endWorkingHours;

        public AvailableAppointmentService appointmentService;
   
   }
}