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

namespace Service.ScheduleService
{
   public class AppointmentService
   {
        public AppointmentService(IAppointmentRepository appointmentRepository, WorkDayService workDayService, NotificationService notificationService,
            int allowedPeriodOfTime, int appointmentTimePeriod, int surgeryPeriod, int appointmentHourStart, int appointmentHourEnd)
        {
            this.appointmentHourStart = appointmentHourStart;
            this.appointmentHourEnd = appointmentHourEnd;
            this.appointmentRepository = appointmentRepository;
            this.workDayService = workDayService;
            this.allowedPeriodOfTime = allowedPeriodOfTime;
            this.appointmentTimePeriod = appointmentTimePeriod;
            this.surgeryPeriod = surgeryPeriod;
            this.notificationService = notificationService;
        }


        public Appointment GetAppointment(int appointmentId) => appointmentRepository.GetObject(appointmentId);

        public Appointment AddAppointment(Appointment appointment, bool ifUrgent)
        {
            Appointment fullAppointment = appointment;
            if (CheckAllParameters(appointment, ifUrgent))
            {
                appointmentRepository.Create(appointment);
                notificationService.AppointmentNotifyForDoctors(fullAppointment);
                notificationService.AppointmentNotifyForPatients(fullAppointment);
                return appointment;
            }
            return null;
        }
        public Appointment ChangeRoomForAppointment(Appointment appointment, Room room)
        {
            Appointment appointmentToUpdate = appointmentRepository.GetObject(appointment.Id);
            appointmentToUpdate.Room = room;
            return appointmentRepository.Update(appointmentToUpdate);
        }
        public IEnumerable<Appointment> NotFinishedByDoctorAndDay(Doctor doctor, DateTime day)
        {
            var doctorsDay = GetScheduledBy(doctor, day);
            return doctorsDay.Where(entity => !entity.Finished);
        }
        public int GetNumberOfAppointmentsFor(Doctor doctor, TypeOfAppointment type)
        {
            var allExams = appointmentRepository.GetAll().ToList().Where(entity => entity.IsDoctor(doctor));
            return allExams.Where(entity => entity.Finished == true && entity.TypeOfAppointment == type).ToList().Count;
        }

        public Appointment FinishAppointment(Appointment appointment)
        {
            appointment.Finished = true;
            return appointmentRepository.Update(appointment);
        }

        public Appointment GetCurrentAppointment(Doctor doctor, MedicalRecord medicalRecord)
        {
            var doctorsDay = GetScheduledBy(doctor, DateTime.Today);
            return doctorsDay.SingleOrDefault(entity => entity.IsMedicalRecord(medicalRecord));
        }
        public Appointment ChangeDoctorForAppointment(Doctor doctor, Appointment appointment)
        {
            Appointment appointmentToUpdate = appointmentRepository.GetObject(appointment.Id);
            appointmentToUpdate.Doctor = doctor;
            return appointmentRepository.Update(appointmentToUpdate);
        }
      
        public Appointment ChangeTimeOfAppointment(Appointment appointment, DateTime termOfAppointment)
        {
            Appointment appointmentToUpdate = appointmentRepository.GetObject(appointment.Id);
            appointmentToUpdate.Period.StartTime = termOfAppointment;
            int ifSurgeryMultiply = appointment.TypeOfAppointment == TypeOfAppointment.Surgery ? surgeryPeriod : 1;
            appointmentToUpdate.Period.EndTime = termOfAppointment.AddMinutes(appointmentTimePeriod * ifSurgeryMultiply);
            return appointmentRepository.Update(appointmentToUpdate);
        }

        public bool DeleteAppointment(Appointment appointment) => 
            appointmentRepository.Delete(appointment);

        public IEnumerable<Appointment> GetScheduledBy(DateTime date) => 
            appointmentRepository.GetAppointmentsBy(date).Values;

        public IEnumerable<Appointment> GetScheduledBy(Doctor doctor, DateTime date)
        {
            var allScheduledByDay = GetScheduledBy(date);
            List<Appointment> appointmentsByDoctor = new List<Appointment>();
            foreach (Appointment appointment in allScheduledByDay)
            {
                if (appointment.IsDoctor(doctor))
                    appointmentsByDoctor.Add(appointment);
            }
            return appointmentsByDoctor;
        }
      
        public Appointment GetScheduledFor(Patient patient)
        {
            var scheduledByDate = appointmentRepository.GetScheduledFromToday();
            List<Appointment> scheduled = new List<Appointment>();
            foreach (Appointment appointment in scheduledByDate.Values)
            {
                if (appointment.IsPatient(patient))
                    return appointment;
            }
            throw new NoAppointmentsFound();
        } 

        public bool CheckAllParameters(Appointment appointment, bool ifUrgent)
        {
            var appointmentsForPatient = GetScheduledFor(appointment.MedicalRecord.Patient);
            if (appointmentsForPatient != null && !ifUrgent)
                throw new AppointmentAlreadyOccupied(PATIENT_ALREADY_HAS_SCHEDULED);
            if (appointment.IsTooEarlyToSchedule(allowedPeriodOfTime))
                throw new NotValidTimeForScheduling(string.Format(CANT_SCHEDULE, allowedPeriodOfTime));
            if (appointmentRepository.GetAll().Any(ent => ent.IsAlreadyScheduled(appointment.Period.StartTime) 
                                                          && ent.Doctor.Username.Equals(appointment.Doctor.Username)))
                throw new AppointmentAlreadyOccupied(string.Format(ALREADY_SCHEDULED, appointment.Period.StartTime.ToString("dd.MM.yyyy. HH:mm")));
            return true;
        }

        private const string ALREADY_SCHEDULED = "Appointment with start time {0} already scheduled!";
        private const string CANT_SCHEDULE = "Appointments can be scheduled after {0} hours from now!";
        private const string PATIENT_ALREADY_HAS_SCHEDULED = "Patient already has scheduled appointment.";

        public int allowedPeriodOfTime;
        public int appointmentTimePeriod;
        public int appointmentHourStart;
        public int appointmentHourEnd;
        public int surgeryPeriod;


        public IAppointmentRepository appointmentRepository;
        public WorkDayService workDayService;
        public NotificationService notificationService;
        public IPriorityStrategy strategy;
        
   
   }
}