using Model.Schedule;
using Model.Users;
using Repository.ScheduleRepository;
using Service.ScheduleService;
using Service.UserService;
using SimsProjekat.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Repository.ScheduleRepository
{
    public class AvailableAppointmentService
    {
        public AvailableAppointmentService(IAppointmentRepository appointmentRepository, WorkDayService workDayService,
            int allowedPeriodOfTime, int appointmentTimePeriod, int surgeryPeriod, int appointmentHourStart, int appointmentHourEnd)
        {
            this.appointmentHourStart = appointmentHourStart;
            this.appointmentHourEnd = appointmentHourEnd;
            this.appointmentRepository = appointmentRepository;
            this.workDayService = workDayService;
            this.allowedPeriodOfTime = allowedPeriodOfTime;
            this.appointmentTimePeriod = appointmentTimePeriod;
            this.surgeryPeriod = surgeryPeriod;
            this.surgeryMultiplyTime = (int)Math.Ceiling((double)surgeryPeriod / (double)appointmentTimePeriod);
        }


        public Dictionary<int, Appointment> ScheduleForUrgentAppointments(DateTime date, TypeOfAppointment type)
        {
            if (type == TypeOfAppointment.examination)
            {
                return GetAvailabeUrgentExamination(date);
            } else
            {
                return GetAvailabeUrgentSurgery(date);
            }
        }
        public Dictionary<int, Appointment> ScheduleAppointemnts(DateTime date, TypeOfAppointment type)
        {
            if (type == TypeOfAppointment.examination)
            {
                return GetAvailableExamination(date);
            }
            else
            {
                return GetAvailabeSurgery(date);
            }
        }

        public Dictionary<int, Appointment> GetAvailabeUrgentExamination(DateTime date)
        {
            var availableAppointments = FindFreeExaminations(date);
            CheckIfRoomsAreAvailable(availableAppointments, date);
            return availableAppointments;
        }

        public Dictionary<int, Appointment> GetAvailabeUrgentSurgery(DateTime date)
        {

            var availableAppointments = FindFreeSurgery(date);
            CheckIfRoomsAreAvailable(availableAppointments, date);
            return availableAppointments;
        }
        public Dictionary<int, Appointment> GetAvailableExamination(DateTime date)
        {
            if (isTimeAllowed(date))
            {
                return new Dictionary<int, Appointment>();
            }
           
            var availableAppointments = FindFreeExaminations(date);
            CheckIfRoomsAreAvailable(availableAppointments, date);
            return availableAppointments;

        }

        public Dictionary<int, Appointment> GetAvailabeSurgery(DateTime date)
        {
            if (isTimeAllowed(date))
            {
                return new Dictionary<int, Appointment>();
            }
            var availableAppointments = FindFreeSurgery(date);
            CheckIfRoomsAreAvailable(availableAppointments, date);
            return availableAppointments;
        }
        // podsetnik, promeni kod sekretara poziv funkcije
        private bool isTimeAllowed(DateTime date)
        {
            return date.Date.CompareTo(DateTime.Today.Date.AddHours(allowedPeriodOfTime)) <= 0;
        }

        public Dictionary<int, Appointment> UrgentAppointemntsForDoctor(DateTime date, Doctor doctor, TypeOfAppointment type)
        {
            var allAvailableByDate = ScheduleForUrgentAppointments(date, type);
            Dictionary<int, Appointment> availableAppointments = new Dictionary<int, Appointment>();
            foreach (Appointment appointment in allAvailableByDate.Values)
            {
                if (appointment.Doctor.Username.Equals(doctor.Username))
                    availableAppointments.Add(appointment.GetHashCode(), appointment);

            }
            return availableAppointments;
        }

        public Dictionary<int, Appointment> AppointemntsForDoctor(DateTime date, Doctor doctor, TypeOfAppointment type)
        {
            var allAvailableByDate = ScheduleAppointemnts(date, type);
            Dictionary<int, Appointment> availableAppointments = new Dictionary<int, Appointment>();
            foreach (Appointment appointment in allAvailableByDate.Values)
            {
                if (appointment.Doctor.Username.Equals(doctor.Username))
                    availableAppointments.Add(appointment.GetHashCode(), appointment);

            }
            return availableAppointments;


        }

        private void CheckIfRoomsAreAvailable(Dictionary<int, Appointment> availableAppointments, DateTime date)
        {
            var allScheduledForDay = appointmentRepository.GetAppointmentsByDate(date.Date);
            foreach (Appointment appointment in allScheduledForDay.Values)
            {
                foreach (Appointment availableAppointment in availableAppointments.Values)
                {
                    if (appointment.StartTime.CompareTo(availableAppointment.StartTime) >= 0 && appointment.StartTime.CompareTo(availableAppointment.EndTime) < 0
                        && appointment.Room.Id == availableAppointment.Room.Id)
                    {
                        availableAppointments.Remove(availableAppointment.GetHashCode());
                    }
                }
            }
        }

        private Dictionary<int, Appointment> FindFreeExaminations(DateTime date)
        {
            var allWorkingDoctorsForDay = workDayService.GetWorkingDoctorsForDay(date.Date);
            foreach (WorkDay workDay in allWorkingDoctorsForDay)
            {
                return CheckWorkDayForExamination(workDay);
            }
            return new Dictionary<int, Appointment>();
        }

        private Dictionary<int, Appointment> FindFreeSurgery(DateTime date)
        {
            var allWorkingDoctorsForDay = workDayService.GetWorkingDoctorsForDay(date.Date);
            foreach (WorkDay workDay in allWorkingDoctorsForDay)
            {
                return CheckWorkDayForSurgery(workDay);
            }
            return new Dictionary<int, Appointment>();
        }

        private Dictionary<int, Appointment> CheckWorkDayForExamination(WorkDay workDay)
        {
            DateTime startTime = new DateTime(workDay.Date.Year, workDay.Date.Month, workDay.Date.Day, workDay.Shift.StartHour, 0, 0);
            DateTime endTime = new DateTime(workDay.Date.Year, workDay.Date.Month, workDay.Date.Day, workDay.Shift.EndHour, 0, 0);
            Dictionary<int, Appointment> availableAppointments = new Dictionary<int, Appointment>();
            var allScheduled = appointmentRepository.GetAppointmentsByDate(workDay.Date);
            while (startTime.CompareTo(endTime) < 0)
            {
                Appointment appointment = new Appointment(startTime, startTime.AddMinutes(appointmentTimePeriod),
                    (Doctor)workDay.Employee, TypeOfAppointment.examination);
                if (!allScheduled.ContainsKey(appointment.GetHashCode()) && !(appointment.EndTime.Hour > workDay.Shift.EndHour))
                {
                    appointment.TypeOfAppointment = TypeOfAppointment.examination;
                    availableAppointments.Add(appointment.GetHashCode(), appointment);
                }
                startTime = startTime.AddMinutes(appointmentTimePeriod);
            }
            return availableAppointments;
        }

        private Dictionary<int, Appointment> CheckWorkDayForSurgery(WorkDay workDay)
        {

            DateTime startTime = new DateTime(workDay.Date.Year, workDay.Date.Month, workDay.Date.Day, workDay.Shift.StartHour, 0, 0);
            DateTime endTime = new DateTime(workDay.Date.Year, workDay.Date.Month, workDay.Date.Day, workDay.Shift.EndHour, 0, 0);
            Dictionary<int, Appointment> availableAppointments = new Dictionary<int, Appointment>();
            var allScheduled = appointmentRepository.GetAppointmentsByDate(workDay.Date);
            while (startTime.CompareTo(endTime) < 0)
            {
                Appointment appointment = new Appointment(startTime, startTime.AddMinutes(appointmentTimePeriod * surgeryMultiplyTime),
                    (Doctor)workDay.Employee, TypeOfAppointment.examination);
                if (!allScheduled.ContainsKey(appointment.GetHashCode()) && !(appointment.EndTime.Hour > workDay.Shift.EndHour) 
                    && ifCanScheduleSurgery(appointment))
                {
                    appointment.TypeOfAppointment = TypeOfAppointment.examination;
                    availableAppointments.Add(appointment.GetHashCode(), appointment);
                }
                startTime = startTime.AddMinutes(appointmentTimePeriod);
            }
            return availableAppointments;
        }

        private bool ifCanScheduleSurgery(Appointment appointment)
        {
            bool somethingBetweenScheduled = false;
            DateTime checkFrom = appointment.StartTime;
            var allScheduled = appointmentRepository.GetAppointmentsByDate(appointment.StartTime.Date);
            while (checkFrom.CompareTo(appointment.EndTime) < 0)
            {
                Appointment appointmentToCheck = new Appointment(checkFrom, checkFrom.AddMinutes(appointmentTimePeriod), appointment.Doctor, TypeOfAppointment.surgery);
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
                throw new CantFindAppointment(CANT_RECOMMEND);
            return toRecommend;
        }

        public void SwitchStrategy(PriorityType priority)
        {
            if (priority == PriorityType.doctor)
                strategy = new DoctorPriorityStrategy(this, appointmentHourStart, appointmentHourEnd);
            else
                strategy = new DatePrirorityStrategy(this, appointmentHourStart, appointmentHourEnd);
        }


        private const string CANT_RECOMMEND = "Can't find any appointment to recommend!";

        public int allowedPeriodOfTime;
        public int appointmentTimePeriod;
        public int appointmentHourStart;
        public int appointmentHourEnd;
        public int surgeryPeriod;
        public int surgeryMultiplyTime;

        public IAppointmentRepository appointmentRepository;
        public WorkDayService workDayService;
        public IPriorityStrategy strategy;
    }
}
