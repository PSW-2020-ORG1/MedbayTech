using Model.Schedule;
using Model.Users;
using Service.ScheduleService;
using SimsProjekat.Repository.ScheduleRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Controller.ScheduleController
{
    public class AvailableAppointmentController
    {
        public AvailableAppointmentController(AvailableAppointmentService appointmentService)
        {
            this.availableAppointmentService = appointmentService;
        }

        public Appointment RecommendAppointment(PriorityParameters parameters) => availableAppointmentService.RecommendAppointment(parameters);
        public Dictionary<int, Appointment> FindAvailable(DateTime date, TypeOfAppointment type) => availableAppointmentService.ScheduleAppointemnts(date, type);

        public Dictionary<int, Appointment> FindAvailableUrgent(DateTime date, TypeOfAppointment type) => availableAppointmentService.ScheduleForUrgentAppointments(date, type);
        public Dictionary<int, Appointment> AvailableDoctorsAppointment(DateTime date, Doctor doctor, TypeOfAppointment type) => availableAppointmentService.AppointemntsForDoctor(date, doctor, type);
        public Dictionary<int, Appointment> AvailableDoctorsUrgentAppointment(DateTime date, Doctor doctor, TypeOfAppointment type) => availableAppointmentService.UrgentAppointemntsForDoctor(date, doctor, type);


        public AvailableAppointmentService availableAppointmentService;
    }

}
