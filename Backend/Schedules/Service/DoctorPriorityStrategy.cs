// File:    DoctorPriorityStrategy.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 1:09:09 AM
// Purpose: Definition of Class DoctorPriorityStrategy

using Model.Schedule;
using Model.Users;
using SimsProjekat.Repository.ScheduleRepository;
using System;
using System.Collections.Generic;

namespace Service.ScheduleService
{
   public class DoctorPriorityStrategy : IPriorityStrategy
   {
        public Appointment Recommend(PriorityParameters parameters)
        {
            DateTime startFrom = new DateTime(parameters.ChosenStartDate.Year, parameters.ChosenStartDate.Month, parameters.ChosenStartDate.Day, startWorkingHours, 0, 0);
            parameters.ChosenEndDate = new DateTime(parameters.ChosenEndDate.Year, parameters.ChosenEndDate.Month, parameters.ChosenEndDate.Day, endWorkingHours, 0, 0);
            List<Appointment> allAppointmentsInTimePeriod = new List<Appointment>();
            while (startFrom.Date.CompareTo(parameters.ChosenEndDate) < 0)
            {
                var appointmentsForDoctors = appointmentService.AppointemntsForDoctor(startFrom, parameters.ChosenDoctor, TypeOfAppointment.examination);
                allAppointmentsInTimePeriod.AddRange(appointmentsForDoctors.Values);
                startFrom = startFrom.AddDays(1);
            }
            return RecommendResults(allAppointmentsInTimePeriod, parameters);
        }

        public Appointment RecommendResults(List<Appointment> allAppointmentsInTimePeriod, PriorityParameters parameters)
        {
            foreach (Appointment appointment in allAppointmentsInTimePeriod)
            {
                Console.WriteLine(appointment.StartTime.ToString("dd.MM.yyyy. HH:mm:ss") + " " + appointment.EndTime.ToString("dd.MM.yyyy. HH:mm:ss"));
            }
            if (allAppointmentsInTimePeriod.Count > 0)
                return allAppointmentsInTimePeriod[rndGen.Next(0, allAppointmentsInTimePeriod.Count)];

            return RecommendAfterDate(parameters);   
        }

        private Appointment RecommendAfterDate(PriorityParameters parameters)
        {
            Appointment appointmentToRecommend = null;
            while (appointmentToRecommend != null)
            {
                DateTime startFrom = parameters.ChosenEndDate.Date.AddDays(1);
                List<Appointment> allAppointmentsInTimePeriod = new List<Appointment>();
                var appointmentsForDoctors = appointmentService.AppointemntsForDoctor(startFrom, parameters.ChosenDoctor, TypeOfAppointment.examination);
                foreach (Appointment appointment in appointmentsForDoctors.Values)
                {
                    appointmentToRecommend = appointment;
                    break;
                }
            }
            return appointmentToRecommend;
        }

        public DoctorPriorityStrategy(AvailableAppointmentService appointmentService, int startHours, int endHours)
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