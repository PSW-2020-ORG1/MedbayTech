using Backend.Schedules.Service.Interfaces;
using Backend.Users.Repository;
using Model.Rooms;
using Model.Schedule;
using Model.Users;
using Repository.RoomRepository;
using Service.ScheduleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Schedules.Service
{
    public class AppointmentFilterService : IAppointmentFilterService
    {
        private IAppointmentService _appointmentService;
        private IDoctorRepository _doctorRepository;
        private IHospitalEquipmentRepository _hospitalEquipmentRepository;

        public AppointmentFilterService(IAppointmentService appointmentService, IDoctorRepository doctorRepository, IHospitalEquipmentRepository hospitalEquipmentRepository)
        {
            _appointmentService = appointmentService;
            _doctorRepository = doctorRepository;
            _hospitalEquipmentRepository = hospitalEquipmentRepository;
        }

        public List<Appointment> GetAvailableByDoctorTimeIntervalAndEquipment(PriorityParameters parameters, int hospitalEquipmentId, string priority)
        {
            List<Appointment> allAppointments;
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

        public List<Appointment> AddRoomToAppointment(List<Appointment> appointments)
        {
            foreach (Appointment appointment in appointments)
            {
                List<Doctor> doctors = _doctorRepository.GetAll().ToList();
                Doctor doctor = _doctorRepository.GetObject(appointment.DoctorId);
                appointment.RoomId = doctor.ExaminationRoomId;
                appointment.Room = doctor.ExaminationRoom;
            }
            return appointments;
        }

        private List<Appointment> FilterAllApointments(List<Appointment> allAppointments, int hospitalEquipmentId)
        {
            List<Appointment> appointments = new List<Appointment>();
            List<HospitalEquipment> hospitalEquipments = _hospitalEquipmentRepository.GetAll().ToList().Where(h => h.EquipmentTypeId == hospitalEquipmentId).ToList();
            foreach (Appointment appointment in allAppointments)
            {
                foreach (HospitalEquipment hospitalEquipment in hospitalEquipments)
                {
                    if (appointment.RoomId == hospitalEquipment.RoomId) appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public List<Appointment> GetAvailableByPriorityTimeInterval(PriorityParameters parameters)
        {
            List<Appointment> appointmentsForAllDoctors = new List<Appointment>();
            List<Doctor> doctors = _doctorRepository.GetAll().ToList();
            foreach (Doctor doctor in doctors)
            {
                parameters.DoctorId = doctor.Id;
                appointmentsForAllDoctors.AddRange(_appointmentService.GetAvailableByDoctorAndTimeInterval(parameters));
            }

            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in appointmentsForAllDoctors)
            {
                if (appointment.Start >= parameters.ChosenStartDate && appointment.End <= parameters.ChosenEndDate) appointments.Add(appointment);
            }
            AddRoomToAppointment(appointments);
            return appointments;
        }
    }
}
