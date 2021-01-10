using Application.Common.Interfaces.Service;
using Application.DTO;
using MedbayTech.Appointment.Application.Common.Interfaces.Service;
using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Appointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Services
{
    public class AppointmentFilterService : IAppointmentFilterService
    {
        private static int addDays = 5;
        private readonly IAppointmentService _appointmentService;
        private readonly IUserGateway _userGateway;
        private readonly IRoomGateway _roomGateway;
        

        public AppointmentFilterService(IAppointmentService appointmentService, IUserGateway userGateway, IRoomGateway roomGateway)
        {
            _appointmentService = appointmentService;
            _userGateway = userGateway;
            _roomGateway = roomGateway;
        }

        public List<Domain.Entities.Appointment> GetAvailableByDoctorTimeIntervalAndEquipment(PriorityParameters parameters, int hospitalEquipmentId, string priority)
        {
            List<MedbayTech.Appointment.Domain.Entities.Appointment> allAppointments;
            if (priority.Equals("doctor"))
            {
                allAppointments = _appointmentService.GetAvailableByPriorityDoctor(parameters);
            }
            else if (priority.Equals("timeinterval"))
            {
                allAppointments = GetAvailableByPriorityTimeInterval(parameters);
            }
            else
            {
                allAppointments = _appointmentService.GetAvailableByDoctorAndTimeInterval(parameters);
            }
            allAppointments = AddRoomToAppointment(allAppointments);
            return FilterAllApointments(allAppointments, hospitalEquipmentId);
        }

        public List<Domain.Entities.Appointment> AddRoomToAppointment(List<MedbayTech.Appointment.Domain.Entities.Appointment> appointments)
        {
            foreach (Domain.Entities.Appointment appointment in appointments)
            {
                Doctor doctor = _userGateway.GetDoctorBy(appointment.DoctorId);             
                appointment.RoomId = doctor.ExaminationRoomId;
                appointment.Room = _roomGateway.GetRoomBy(appointment.RoomId);
            }
            return appointments;
        }

        private List<Domain.Entities.Appointment> FilterAllApointments(List<MedbayTech.Appointment.Domain.Entities.Appointment> allAppointments, int hospitalEquipmentId)
        {
            List<Domain.Entities.Appointment> appointments = new List<MedbayTech.Appointment.Domain.Entities.Appointment>();
            List<HospitalEquipment> hospitalEquipments = _roomGateway.GetAllHospitalEquipments().ToList().Where(h => h.EquipmentTypeId == hospitalEquipmentId).ToList();
            foreach (Domain.Entities.Appointment appointment in allAppointments)
            {
                foreach (HospitalEquipment hospitalEquipment in hospitalEquipments)
                {
                    if (appointment.RoomId == hospitalEquipment.RoomId) appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public List<Domain.Entities.Appointment> GetAvailableByPriorityTimeInterval(PriorityParameters parameters)
        {
            List<MedbayTech.Appointment.Domain.Entities.Appointment> appointmentsForAllDoctors = new List<MedbayTech.Appointment.Domain.Entities.Appointment>();
            List<Doctor> doctors = _userGateway.GetAllDoctors();
            foreach (Doctor doctor in doctors)
            {
                parameters.DoctorId = doctor.Id;
                appointmentsForAllDoctors.AddRange(_appointmentService.GetAvailableByDoctorAndTimeInterval(parameters));
            }

            List<MedbayTech.Appointment.Domain.Entities.Appointment> appointments = new List<MedbayTech.Appointment.Domain.Entities.Appointment>();
            foreach (MedbayTech.Appointment.Domain.Entities.Appointment appointment in appointmentsForAllDoctors)
            {
                if (appointment.Period.StartTime >= parameters.ChosenStartDate && appointment.Period.EndTime <= parameters.ChosenEndDate) appointments.Add(appointment);
            }
            AddRoomToAppointment(appointments);
            return appointments;
        }

        public List<Domain.Entities.Appointment> FindEmergencyAppointment(PriorityParameters parameters, int equipmentType)
        {
            List<Domain.Entities.Appointment> filteredAppointments = new List<Domain.Entities.Appointment>();
            List<Domain.Entities.Appointment> appointmentsForAllDoctors = GetAvailableByPriorityTimeInterval(parameters);
            appointmentsForAllDoctors = AddRoomToAppointment(appointmentsForAllDoctors);
            foreach (Domain.Entities.Appointment appointment in appointmentsForAllDoctors)
            {
                if (equipmentType != -1)
                {
                    if (appointment.Doctor.SpecializationId == parameters.SpecializationId && IsEquipmentTypePresentInRoom(appointment, equipmentType))
                    {
                        appointment.Urgent = true;
                        filteredAppointments.Add(appointment);
                    }
                }
                else
                {
                    if (appointment.Doctor.SpecializationId == parameters.SpecializationId)
                    {
                        appointment.Urgent = true;
                        filteredAppointments.Add(appointment);
                    }
                }

            }
            if (filteredAppointments.Count > 0)
            {
                return FindMostRecentAppointment(filteredAppointments);
            }
            return new List<Domain.Entities.Appointment>();
        }

        public Tuple<List<Domain.Entities.Appointment>, List<int>> FindAppointmentsForRescheduling(PriorityParameters parameters, int equipmentType)
        {
            Doctor doctor = _userGateway.GetDoctorBy(parameters.DoctorId);
            List<Domain.Entities.Appointment> potentionalAppointmentsForRescheduling;
            Dictionary<Domain.Entities.Appointment, int> dictionarytPostPoneTime = new Dictionary<Domain.Entities.Appointment, int>();
            if (equipmentType == -1)
            {
                potentionalAppointmentsForRescheduling = _appointmentService.GetAll().Where(a => a.Period.StartTime >= parameters.ChosenStartDate && a.Period.EndTime <= parameters.ChosenEndDate && a.Urgent == false && a.Doctor.SpecializationId == doctor.SpecializationId).ToList();
            }
            else
            {
                potentionalAppointmentsForRescheduling = _appointmentService.GetAll().Where(a => a.Period.StartTime >= parameters.ChosenStartDate && a.Period.EndTime <= parameters.ChosenEndDate && a.Urgent == false && a.Doctor.SpecializationId == doctor.SpecializationId).ToList();
                List<Domain.Entities.Appointment> appointments = new List<Domain.Entities.Appointment>();
                foreach (Domain.Entities.Appointment appointment in potentionalAppointmentsForRescheduling)
                {
                    if (IsEquipmentTypePresentInRoom(appointment, equipmentType)) appointments.Add(appointment);
                }
                potentionalAppointmentsForRescheduling = appointments;
            }
            foreach (Domain.Entities.Appointment appointment in potentionalAppointmentsForRescheduling)
            {
                Domain.Entities.Appointment a = _appointmentService.GetAvailableByDoctorAndTimeInterval(new PriorityParameters() { DoctorId = appointment.DoctorId, ChosenStartDate = parameters.ChosenEndDate, ChosenEndDate = parameters.ChosenEndDate.AddDays(addDays) })[0];
                int time = (int)(a.Period.StartTime - appointment.Period.EndTime).TotalMinutes;
                dictionarytPostPoneTime.Add(appointment, time);
            }
            List<Domain.Entities.Appointment> keyList = new List<Domain.Entities.Appointment>(dictionarytPostPoneTime.Keys);
            List<int> valueList = new List<int>(dictionarytPostPoneTime.Values);
            return Tuple.Create(keyList, valueList);
        }

        bool IsEquipmentTypePresentInRoom(Domain.Entities.Appointment appointment, int equipmentType)
        {
            List<HospitalEquipment> hospitalEquipment = _roomGateway.GetHospitalEquipmentByRoom(appointment.RoomId);
            if (hospitalEquipment.Where(a => a.EquipmentTypeId == equipmentType).ToList().Count > 0)
            {
                return true;
            }
            else return false;
        }

        List<Domain.Entities.Appointment> FindMostRecentAppointment(List<Domain.Entities.Appointment> filteredAppointments)
        {
            Domain.Entities.Appointment mostRecentApp = filteredAppointments.ElementAt(0);
            foreach (Domain.Entities.Appointment appointment in filteredAppointments)
            {
                if (appointment.Period.StartTime < mostRecentApp.Period.StartTime) mostRecentApp = appointment;
            }
            List<Domain.Entities.Appointment> newList = new List<Domain.Entities.Appointment>();
            newList.Add(mostRecentApp);
            return newList;
        }
    }
}
