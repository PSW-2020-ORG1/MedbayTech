// File:    AppointmentController.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 11:51:47 PM
// Purpose: Definition of Class AppointmentController

using Backend.Records.Model;
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
        public Appointment AddAppointment(Appointment appointment, bool ifUrgent) => 
            appointmentService.AddAppointment(appointment, ifUrgent);

        public Appointment ChangeRoomForAppointment(Appointment appointment, Room room) => 
            appointmentService.ChangeRoomForAppointment(appointment, room);

        public Appointment ChangeDoctorForAppointment(Doctor doctor, Appointment appointment) => 
            appointmentService.ChangeDoctorForAppointment(doctor, appointment);

        public Appointment ChangeTimeOfAppointment(Appointment appointment, DateTime termOfAppointment) => 
            appointmentService.ChangeTimeOfAppointment(appointment, termOfAppointment);

        public bool DeleteAppointment(Appointment appointment) => 
            appointmentService.DeleteAppointment(appointment);

        public Appointment GetAppointment(int appointmentId) => 
            appointmentService.GetAppointment(appointmentId);

        public IEnumerable<Appointment> GetScheduledBy(DateTime date) => 
            appointmentService.GetScheduledBy(date);

        public IEnumerable<Appointment> GetScheduledBy(Doctor doctor, DateTime date) => 
            appointmentService.GetScheduledBy(doctor, date);

        public Appointment GetScheduledFor(Patient patient) => 
            appointmentService.GetScheduledFor(patient);

        public IEnumerable<Appointment> NotFinishedByDoctorAndDay(Doctor doctor, DateTime day) => 
            appointmentService.NotFinishedByDoctorAndDay(doctor, day);

        public Appointment GetCurrentAppointment(Doctor doctor, MedicalRecord medicalRecord) => 
            appointmentService.GetCurrentAppointment(doctor, medicalRecord);

        public Appointment FinishAppointment(Appointment appointment) => 
            appointmentService.FinishAppointment(appointment);

        public int GetNumberOfAppointmentsFor(Doctor doctor, TypeOfAppointment type) => 
            appointmentService.GetNumberOfAppointmentsFor(doctor, type);


        public AppointmentService appointmentService;
    
   }
}