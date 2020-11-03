/***********************************************************************
 * Module:  AppointmentService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.AppointmentService
 ***********************************************************************/

using Model.MedicalRecord;
using Model.Rooms;
using Model.Schedule;
using Model.Users;
using Repository.ScheduleRepository;
using Service.GeneralService;
using Service.UserService;
using SimsProjekat.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Appointment appointmentToUpdate = appointmentRepository.GetObject(appointment.IdAppointment);
            appointmentToUpdate.Room = room;
            return appointmentRepository.Update(appointmentToUpdate);
        }
        public IEnumerable<Appointment> NotFinishedByDoctorAndDay(Doctor doctor, DateTime day)
        {
            var doctorsDay = GetScheduledByDoctorForOneDay(doctor, day);
            return doctorsDay.Where(entity => entity.Finished == false);
        }
        public int GetNumberOfAppointmentsForDoctor(Doctor doctor, TypeOfAppointment type)
        {
            var allExams = appointmentRepository.GetAll().ToList().Where(entity => entity.Doctor.Username.Equals(doctor.Username));
            return allExams.Where(entity => entity.Finished == true && entity.TypeOfAppointment == type).ToList().Count;
        }

        public Appointment FinishAppointment(Appointment appointment)
        {
            appointment.Finished = true;
            return appointmentRepository.Update(appointment);
        }

        public Appointment GetCurrentAppointment(Doctor doctor, MedicalRecord medicalRecord)
        {
            var doctorsDay = GetScheduledByDoctorForOneDay(doctor, DateTime.Today);
            return doctorsDay.SingleOrDefault(entity => entity.MedicalRecord.Id == medicalRecord.Id);
        }
        public Appointment ChangeDoctorForAppointment(Doctor doctor, Appointment appointment)
        {
            Appointment appointmentToUpdate = appointmentRepository.GetObject(appointment.IdAppointment);
            appointmentToUpdate.Doctor = doctor;
            return appointmentRepository.Update(appointmentToUpdate);
        }
      
        public Appointment ChangeDateTimeOfAppointment(Appointment appointment, DateTime termOfAppointmetn)
        {
            Appointment appointmentToUpdate = appointmentRepository.GetObject(appointment.IdAppointment);
            appointmentToUpdate.StartTime = termOfAppointmetn;
            int ifSurgeryMultiply = appointment.TypeOfAppointment == TypeOfAppointment.surgery ? 5 : 1;
            appointmentToUpdate.EndTime = termOfAppointmetn.AddMinutes(appointmentTimePeriod * ifSurgeryMultiply);
            return appointmentRepository.Update(appointmentToUpdate);
        }

        public bool DeleteAppointment(Appointment appointment) => appointmentRepository.Delete(appointment);

        public IEnumerable<Appointment> GetScheduledByDay(DateTime date) => appointmentRepository.GetAppointmentsByDate(date).Values;

        public IEnumerable<Appointment> GetScheduledByDoctorForOneDay(Doctor doctor, DateTime date)
        {
            var allScheduledByDay = GetScheduledByDay(date);
            List<Appointment> appointmentsByDoctor = new List<Appointment>();
            foreach (Appointment appointment in allScheduledByDay)
            {
                if (appointment.Doctor.Username.Equals(doctor.Username))
                    appointmentsByDoctor.Add(appointment);
            }
            return appointmentsByDoctor;
        }
      
        public Appointment GetScheduledForPatient(Patient patient)
        {
            var scheduledByDate = appointmentRepository.GetScheduledFromToday();
            List<Appointment> scheduled = new List<Appointment>();
            foreach (Appointment appointment in scheduledByDate.Values)
            {
                if (appointment.MedicalRecord.Patient.Username.Equals(patient.Username))
                    return appointment;
            }
            return null;
        } 


        public bool CheckAllParameters(Appointment appointment, bool ifUrgent)
        {
            if (CheckIfAlreadyScheduled(appointment) && CheckIfTooEarlyToSchedule(appointment, ifUrgent)
                && CheckIfPatientAlreadyScheduled(appointment, ifUrgent))
                return true;
            return false;
        }
        
        private bool CheckIfPatientAlreadyScheduled(Appointment appointment, bool ifUrgent)
        {
            var appointmentsForPatient = GetScheduledForPatient(appointment.MedicalRecord.Patient);
            if (appointmentsForPatient != null && !ifUrgent)
                throw new PatientAlreadyHasAnAppointment(PATIENT_ALREADY_HAS_SCHEDULED);
            return true;
        }
        private bool CheckIfTooEarlyToSchedule(Appointment appointment, bool ifUrgent)
        {
            if (appointment.StartTime.Date.CompareTo(DateTime.Now.AddHours(allowedPeriodOfTime).Date) <= 0 && !ifUrgent)
                throw new NotValidTimeForScheduling(string.Format(CANT_SCHEDULE, allowedPeriodOfTime));
            return true;
        }

        private bool CheckIfAlreadyScheduled(Appointment appointment)
        {
            if (appointmentRepository.GetAll().Any(ent => ent.StartTime.CompareTo(appointment.StartTime) == 0 && ent.Doctor.Username.Equals(appointment.Doctor.Username)))
                throw new AlreadyScheduled(string.Format(ALREADY_SCHEDULED, appointment.StartTime.ToString("dd.MM.yyyy. HH:mm")));
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