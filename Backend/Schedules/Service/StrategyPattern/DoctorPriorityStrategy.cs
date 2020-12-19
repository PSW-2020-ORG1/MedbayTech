using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Schedules.Service.Interfaces;
using Model.Schedule;
using Service.ScheduleService;

namespace Backend.Schedules.Service.StrategyPattern
{
    public class DoctorPriorityStrategy : IPriorityStrategy
    {
        private const int MIN_DAYS = -10;
        private const int MAX_DAYS = 10;
        private const int NUMBER_OF_RECOMMENDED_APPOINTMENTS = 3;
        private IAppointmentService _appointmentService;

        public DoctorPriorityStrategy(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public List<Appointment> Recommend(PriorityParameters parameters)
        {
            List<Appointment> appointmentsBeforeDate = new List<Appointment>();
            List<Appointment> appointentsAfterDate = GetAppointmentsAfterDate(parameters);
            List<Appointment> recommendedAppointments = GetAppointmentsBeforeDate(parameters);

            recommendedAppointments.AddRange(appointmentsBeforeDate);
            recommendedAppointments.AddRange(appointentsAfterDate);

            return recommendedAppointments;
        }

        private List<Appointment> GetAppointmentsAfterDate(PriorityParameters parameters)
        {
            DateTime endDate = parameters.ChosenEndDate.Date.AddDays(1);
            DateTime maxDate = parameters.ChosenEndDate.Date.AddDays(MAX_DAYS);
            List<Appointment> availableAppointments = new List<Appointment>();

            while (endDate <= maxDate)
            {
                List<Appointment> availaAppointments2 =
                    _appointmentService.GetAvailableBy(parameters.DoctorId, endDate);
                availableAppointments.AddRange(availaAppointments2);
                endDate = endDate.AddDays(1);
            }

            return availableAppointments.Where(ap => availableAppointments.IndexOf(ap) < NUMBER_OF_RECOMMENDED_APPOINTMENTS).ToList();
        }

        private List<Appointment> GetAppointmentsBeforeDate(PriorityParameters parameters)
        {
            DateTime startDate = parameters.ChosenStartDate.Date.AddDays(-1);
            DateTime minDate = parameters.ChosenStartDate.Date.AddDays(MIN_DAYS);
            List<Appointment> allAvailableAppointments = new List<Appointment>();

            while (startDate >= minDate || startDate == DateTime.Now.Date)
            {
                List<Appointment> availableAppointments2 =
                    _appointmentService.GetAvailableBy(parameters.DoctorId, startDate);
                allAvailableAppointments.AddRange(availableAppointments2);
                startDate = startDate.AddDays(-1);
            }
            return allAvailableAppointments.Where(ap => allAvailableAppointments.IndexOf(ap) < NUMBER_OF_RECOMMENDED_APPOINTMENTS).ToList();
        }

    }
}
