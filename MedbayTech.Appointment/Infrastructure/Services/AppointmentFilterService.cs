using Application.Common.Interfaces.Service;
using Application.DTO;
using MedbayTech.Appointment.Application.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Services
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

        public List<MedbayTech.Appointment.Domain.Entities.Appointment> GetAvailableByDoctorTimeIntervalAndEquipment(PriorityParameters parameters, int hospitalEquipmentId, string priority)
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

        public List<MedbayTech.Appointment.Domain.Entities.Appointment> AddRoomToAppointment(List<MedbayTech.Appointment.Domain.Entities.Appointment> appointments)
        {
            foreach (MedbayTech.Appointment.Domain.Entities.Appointment appointment in appointments)
            {
                List<Doctor> doctors = _doctorRepository.GetAll().ToList();
                Doctor doctor = _doctorRepository.GetObject(appointment.DoctorId);
                appointment.RoomId = doctor.ExaminationRoomId;
                appointment.Room = doctor.ExaminationRoom;
            }
            return appointments;
        }

        private List<MedbayTech.Appointment.Domain.Entities.Appointment> FilterAllApointments(List<MedbayTech.Appointment.Domain.Entities.Appointment> allAppointments, int hospitalEquipmentId)
        {
            List<MedbayTech.Appointment.Domain.Entities.Appointment> appointments = new List<MedbayTech.Appointment.Domain.Entities.Appointment>();
            List<HospitalEquipment> hospitalEquipments = _hospitalEquipmentRepository.GetAll().ToList().Where(h => h.EquipmentTypeId == hospitalEquipmentId).ToList();
            foreach (MedbayTech.Appointment.Domain.Entities.Appointment appointment in allAppointments)
            {
                foreach (HospitalEquipment hospitalEquipment in hospitalEquipments)
                {
                    if (appointment.RoomId == hospitalEquipment.RoomId) appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public List<MedbayTech.Appointment.Domain.Entities.Appointment> GetAvailableByPriorityTimeInterval(PriorityParameters parameters)
        {
            List<MedbayTech.Appointment.Domain.Entities.Appointment> appointmentsForAllDoctors = new List<MedbayTech.Appointment.Domain.Entities.Appointment>();
            List<Doctor> doctors = _doctorRepository.GetAll().ToList();
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
    }
    {
    }
}
