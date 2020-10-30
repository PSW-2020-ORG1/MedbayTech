// File:    DatePrirorityStrategy.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 1:09:09 AM
// Purpose: Definition of Class DatePrirorityStrategy

using Model.Schedule;
using SimsProjekat.Repository.ScheduleRepository;
using System;
using System.Collections.Generic;

namespace Service.ScheduleService
{
   public class DatePrirorityStrategy : IPriorityStrategy
   {
        public Appointment Recommend(PriorityParameters parameters)
        {
            DateTime startFrom = DateTime.Today;
            if (parameters.ChosenStartDate.Date.CompareTo(DateTime.Today.Date) <= 0)
                startFrom = new DateTime(DateTime.Today.AddDays(1).Year, DateTime.Today.AddDays(1).Month, DateTime.Today.AddDays(1).Day, startWorkingHours, 0, 0);
            else 
                startFrom = new DateTime(parameters.ChosenStartDate.Year, parameters.ChosenStartDate.Month, parameters.ChosenStartDate.Day, startWorkingHours, 0, 0);
            parameters.ChosenEndDate = new DateTime(parameters.ChosenEndDate.Year, parameters.ChosenEndDate.Month, parameters.ChosenEndDate.Day, endWorkingHours, 0, 0);
            List<Appointment> allAppointmentsInTimePeriod = new List<Appointment>();
            while (startFrom.Date.CompareTo(parameters.ChosenEndDate.Date) < 0)
            {
                var appointmentsForDoctors = appointmentService.AppointemntsForDoctor(startFrom.Date, parameters.ChosenDoctor, TypeOfAppointment.examination);
                allAppointmentsInTimePeriod.AddRange(appointmentsForDoctors.Values);
                startFrom = startFrom.AddDays(1);
            }
            return RecommendResults(allAppointmentsInTimePeriod, parameters);
        }

        public Appointment RecommendResults(List<Appointment> allAppointmentsInTimePeriod, PriorityParameters parameters)
        {
            if (allAppointmentsInTimePeriod.Count > 0)
                return RecommendBest(allAppointmentsInTimePeriod, parameters);
            return FindAnyOtherAppoitnemnt(parameters);
        }

        private Appointment FindAnyOtherAppoitnemnt(PriorityParameters parameters)
        {
            DateTime startFrom = parameters.ChosenStartDate;
            List<Appointment> allAppointmentsInTimePeriod = new List<Appointment>();
            while (startFrom.Date.CompareTo(parameters.ChosenEndDate.Date) < 0)
            {
                var appointmentsForDoctors = appointmentService.ScheduleAppointemnts(startFrom, TypeOfAppointment.examination);
                allAppointmentsInTimePeriod.AddRange(appointmentsForDoctors.Values);
                startFrom = startFrom.AddDays(1);
            }
            return RecommendAnyOtherResults(allAppointmentsInTimePeriod, parameters);
        }

        private Appointment RecommendAnyOtherResults(List<Appointment> allAppointmentsInTimePeriod, PriorityParameters parameters)
        {
            DateTime minimumDate = parameters.ChosenEndDate.Date;
            Appointment bestAppointment = null;
            foreach (Appointment appointment in allAppointmentsInTimePeriod)
            {
                if (appointment.StartTime.CompareTo(minimumDate) < 0)
                {
                    minimumDate = appointment.StartTime;
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
                if (appointment.StartTime.CompareTo(minimumDate) < 0)
                {
                    minimumDate = appointment.StartTime;
                    bestAppointment = appointment;
                }
            }
            return bestAppointment;
        }

        public DatePrirorityStrategy(AvailableAppointmentService appointmentService, int startHours, int endHours)
        {
            startWorkingHours = startHours;
            endWorkingHours = endHours;
            rndGen = new Random();
            this.appointmentService = appointmentService;
        }


        private int startWorkingHours;
        private int endWorkingHours;

        private Random rndGen;
        public AvailableAppointmentService appointmentService;
   
   }
}