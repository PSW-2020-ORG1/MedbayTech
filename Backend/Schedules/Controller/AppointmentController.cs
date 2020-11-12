// File:    AppointmentController.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 11:51:47 PM
// Purpose: Definition of Class AppointmentController

using Backend.Records.Model.Enums;
using Model.Rooms;
using Model.Schedule;
using Model.Users;
using Service.ScheduleService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.ScheduleController
{
   public class AppointmentController
   {
        public AppointmentController(AppointmentService appointmentService) 
        {
            this.appointmentService = appointmentService;
        }
        public Appointment AddAppointment(Appointment appointment, bool ifUrgent) => appointmentService.AddAppointment(appointment, ifUrgent);
        public Appointment ChangeRoomForAppointment(Appointment appointment, Room room) => appointmentService.ChangeRoomForAppointment(appointment, room);
        public Appointment ChangeDoctorForAppointment(Doctor doctor, Appointment appointment) => appointmentService.ChangeDoctorForAppointment(doctor, appointment);
        public Appointment ChangeDateTimeOfAppointment(Appointment appointment, DateTime termOfAppointmetn) => appointmentService.ChangeDateTimeOfAppointment(appointment, termOfAppointmetn);
        public bool DeleteAppointment(Appointment appointment) => appointmentService.DeleteAppointment(appointment);
        public Appointment GetAppointment(int appointmentId) => appointmentService.GetAppointment(appointmentId);
        public IEnumerable<Appointment> GetScheduledByDay(DateTime date) => appointmentService.GetScheduledByDay(date);
        public IEnumerable<Appointment> GetScheduledByDoctorForOneDay(Doctor doctor, DateTime date) => appointmentService.GetScheduledByDoctorForOneDay(doctor, date);
        public Appointment GetScheduledForPatient(Patient patient) => appointmentService.GetScheduledForPatient(patient);
        public IEnumerable<Appointment> NotFinishedByDoctorAndDay(Doctor doctor, DateTime day) => appointmentService.NotFinishedByDoctorAndDay(doctor, day);
        public Appointment GetCurrentAppointment(Doctor doctor, MedicalRecord medicalRecord) => appointmentService.GetCurrentAppointment(doctor, medicalRecord);
        public Appointment FinishAppointment(Appointment appointment) => appointmentService.FinishAppointment(appointment);
        public int GetNumberOfAppointmentsForDoctor(Doctor doctor, TypeOfAppointment type) => appointmentService.GetNumberOfAppointmentsForDoctor(doctor, type);

        public AppointmentService appointmentService;
    
   }
}