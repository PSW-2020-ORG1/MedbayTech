using Application.DTO;
using MedbayTech.Appointment.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Common.Interfaces.Service
{
    public interface IAppointmentService
    {
        List<Appointment> GetAppointmentsByPatientId(string id);
        List<Appointment> GetSurveyableAppointments(string id);
        List<Appointment> GetAllOtherAppointments(string id);
        List<Appointment> GetCancelableAppointments(string id);
        bool UpdateCanceled(int appointmentId);
        List<Appointment> InitializeAppointments(string doctorId, DateTime date);
        List<Appointment> GetAvailableBy(string doctorId, DateTime date);
        List<Appointment> GetByDoctorAndDate(string doctorId, DateTime date);
        Appointment ScheduleAppointment(Appointment appointment);
        List<Appointment> GetAvailableByDoctorAndTimeInterval(PriorityParameters parameters);
        List<Appointment> GetAvailableByPriorityDoctor(PriorityParameters parameters);
        List<Appointment> GetApppointmentsScheduledForSpecificRoom(int roomId);
        List<Appointment> GetAvailableByDoctorAndDateRange(PriorityParameters parameters);
        List<Appointment> GetAvailableByStrategy(PriorityParameters parameters);
        List<Appointment> GetAll();
        List<Appointment> GetAppointmentByPatient(string userId);
        Appointment UpdateSuggestedAppointment(Appointment appointment);
    }
}
