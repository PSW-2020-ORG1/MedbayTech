using Model.Schedule;
using Model.Users;
using Repository.ScheduleRepository;
using Service.ScheduleService;
using Service.UserService;
using Backend.Exceptions.Schedules;
using System;
using System.Collections.Generic;
using System.Text;
using SimsProjekat.SIMS.Exceptions;

namespace Backend.General.Model.ScheduleRepository
{
    public class AvailableAppointmentService
    {
        public AvailableAppointmentService(IAppointmentRepository appointmentRepository, WorkDayService workDayService,
            int allowedPeriodOfTime, int appointmentTimePeriod, int appointmentHourStart, int appointmentHourEnd)
        {
            this.appointmentHourStart = appointmentHourStart;
            this.appointmentHourEnd = appointmentHourEnd;
            this.appointmentRepository = appointmentRepository;
            this.workDayService = workDayService;
            this.allowedPeriodOfTime = allowedPeriodOfTime;
            this.appointmentTimePeriod = appointmentTimePeriod;
        }


        public Dictionary<int, Appointment> ScheduleForUrgentAppointments(DateTime date, TypeOfAppointment type)
        {
            urgent = true;
            if (type == TypeOfAppointment.Examination)
                return GetAvailableExaminations(date);
            return GetAvailableSurgeries(date);
            
        }
        public Dictionary<int, Appointment> ScheduleAppointments(DateTime date, TypeOfAppointment type)
        {
            urgent = false;
            if (type == TypeOfAppointment.Examination)
                return GetAvailableExaminations(date);
            return GetAvailableSurgeries(date);
            
        }

        public Dictionary<int, Appointment> GetAvailableExaminations(DateTime date)
        {
            if (!urgent && IsTimeAllowed(date))
                return new Dictionary<int, Appointment>();
            var availableAppointments = AvailableExaminationsFor(date);
            CheckIfRoomsAreAvailable(availableAppointments, date);
            return availableAppointments;
        }

        public Dictionary<int, Appointment> GetAvailableSurgeries(DateTime date)
        {
            if (!urgent && IsTimeAllowed(date))
                return new Dictionary<int, Appointment>();
            var availableAppointments = AvailableSurgeriesFor(date);
            CheckIfRoomsAreAvailable(availableAppointments, date);
            return availableAppointments;
        }
        private bool IsTimeAllowed(DateTime date)
        {
            return date.Date.CompareTo(DateTime.Today.Date.AddHours(allowedPeriodOfTime)) <= 0;
        }

        public Dictionary<int, Appointment> AvailableExaminationsFor(Doctor doctor, DateTime date, bool urgent)
        {
            Dictionary<int, Appointment> availableByDate = new Dictionary<int, Appointment>();
            if (urgent)
                availableByDate = ScheduleForUrgentAppointments(date, TypeOfAppointment.Examination);
            else
                availableByDate = ScheduleAppointments(date, TypeOfAppointment.Examination);
            return FilterAppointmentsBy(doctor, availableByDate);
        }

        public Dictionary<int, Appointment> AvailableSurgeriesFor(Doctor doctor, DateTime date, bool urgent)
        {
            Dictionary<int, Appointment> availableByDate = new Dictionary<int, Appointment>();
            if (urgent)
                availableByDate = ScheduleForUrgentAppointments(date, TypeOfAppointment.Surgery);
            else
                availableByDate = ScheduleAppointments(date, TypeOfAppointment.Surgery);
            return FilterAppointmentsBy(doctor, availableByDate);

        }

        private Dictionary<int, Appointment> FilterAppointmentsBy(Doctor doctor,
            Dictionary<int, Appointment> appointments)
        {
            Dictionary<int, Appointment> availableAppointments = new Dictionary<int, Appointment>();
            foreach (Appointment appointment in appointments.Values)
                if (appointment.IsDoctor(doctor))
                    availableAppointments.Add(appointment.GetHashCode(), appointment);
            return availableAppointments;

        }

        private void CheckIfRoomsAreAvailable(Dictionary<int, Appointment> availableAppointments, DateTime date)
        {
            var allScheduledForDay = appointmentRepository.GetAppointmentsBy(date.Date);
            foreach (Appointment appointment in allScheduledForDay.Values)
            {
                foreach (Appointment availableAppointment in availableAppointments.Values)
                    if (appointment.IsInConflict(availableAppointment))
                        availableAppointments.Remove(availableAppointment.GetHashCode());
            }
        }

        private Dictionary<int, Appointment> AvailableExaminationsFor(DateTime date)
        {
            var allWorkingDoctorsForDay = workDayService.GetWorkingDoctorsForDay(date.Date);
            foreach (WorkDay workDay in allWorkingDoctorsForDay)
                return CheckWorkDay(workDay, TypeOfAppointment.Examination);
            return new Dictionary<int, Appointment>();
        }

        private Dictionary<int, Appointment> AvailableSurgeriesFor(DateTime date)
        {
            var allWorkingDoctorsForDay = workDayService.GetWorkingDoctorsForDay(date.Date);
            foreach (WorkDay workDay in allWorkingDoctorsForDay)
                return CheckWorkDay(workDay, TypeOfAppointment.Surgery);
            return new Dictionary<int, Appointment>();
        }

        private Dictionary<int, Appointment> CheckWorkDay(WorkDay workDay, TypeOfAppointment type)
        {
            DateTime startTime = new DateTime(workDay.Date.Year, workDay.Date.Month, workDay.Date.Day, workDay.Shift.StartHour, 0, 0);
            DateTime endTime = new DateTime(workDay.Date.Year, workDay.Date.Month, workDay.Date.Day, workDay.Shift.EndHour, 0, 0);

            Dictionary<int, Appointment> availableAppointments = new Dictionary<int, Appointment>();

            var allScheduled = appointmentRepository.GetAppointmentsBy(workDay.Date);

            while (startTime.CompareTo(endTime) < 0)
            {
                Appointment appointment = new Appointment();
                if (!allScheduled.ContainsKey(appointment.GetHashCode()) && !(appointment.IsBefore(workDay)))
                {
                    appointment.TypeOfAppointment = type;
                    if (type == TypeOfAppointment.Surgery && IfCanScheduleSurgery(appointment) ||
                            type == TypeOfAppointment.Examination)
                        availableAppointments.Add(appointment.GetHashCode(), appointment);

                }
                startTime = startTime.AddMinutes(appointmentTimePeriod);
            }
            return availableAppointments;
        }

        private bool IfCanScheduleSurgery(Appointment appointment)
        {
            bool somethingBetweenScheduled = false;
            DateTime checkFrom = appointment.Period.StartTime;
            var allScheduled = appointmentRepository.GetAppointmentsBy(appointment.Period.StartTime.Date);
            while (checkFrom.CompareTo(appointment.Period.EndTime) < 0)
            {
                var appointmentToCheck = new Appointment();
                if (allScheduled.ContainsKey(appointmentToCheck.GetHashCode()))
                    somethingBetweenScheduled = true;
                checkFrom = checkFrom.AddMinutes(appointmentTimePeriod);
            }
            return somethingBetweenScheduled;
        }

        public Appointment RecommendAppointment(PriorityParameters parameters)
        {
            SwitchStrategy(parameters.Priority);
            Appointment toRecommend = strategy.Recommend(parameters);
            if (toRecommend == null)
                throw new EntityNotFound(CANT_RECOMMEND);
            return toRecommend;
        }

        public void SwitchStrategy(PriorityType priority)
        {
            if (priority == PriorityType.doctor)
                strategy = new DoctorPriorityStrategy(this, appointmentHourStart, appointmentHourEnd);
            else
                strategy = new DatePriorityStrategy(this, appointmentHourStart, appointmentHourEnd);
        }


        private const string CANT_RECOMMEND = "Can't find any appointment to recommend!";

        private readonly int allowedPeriodOfTime;
        private readonly int appointmentTimePeriod;
        private readonly int appointmentHourStart;
        private readonly int appointmentHourEnd;
        private bool urgent;

        public IAppointmentRepository appointmentRepository;
        public WorkDayService workDayService;
        public IPriorityStrategy strategy;
    }
}
