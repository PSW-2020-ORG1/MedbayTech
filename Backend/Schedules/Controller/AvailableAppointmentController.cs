using Model.Schedule;
using Model.Users;
using Service.ScheduleService;
using Backend.General.Model.ScheduleRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Controller.ScheduleController
{
    public class AvailableAppointmentController
    {
        public AvailableAppointmentController(AvailableAppointmentService appointmentService)
        {
            availableAppointmentService = appointmentService;
        }

        public Appointment RecommendAppointment(PriorityParameters parameters) => 
            availableAppointmentService.RecommendAppointment(parameters);

        public Dictionary<int, Appointment> FindAvailable(DateTime date, TypeOfAppointment type) => 
            availableAppointmentService.ScheduleAppointments(date, type);

        public Dictionary<int, Appointment> FindAvailableUrgent(DateTime date, TypeOfAppointment type) => 
            availableAppointmentService.ScheduleForUrgentAppointments(date, type);

        public Dictionary<int, Appointment> AvailableExaminationsFor(DateTime date, Doctor doctor, bool urgent) => 
            availableAppointmentService.AvailableExaminationsFor(doctor, date, urgent);

        public Dictionary<int, Appointment> AvailableSurgeriesFor(DateTime date, Doctor doctor, bool urgent) =>
            availableAppointmentService.AvailableSurgeriesFor(doctor, date, urgent);




        public AvailableAppointmentService availableAppointmentService;
    }

}
