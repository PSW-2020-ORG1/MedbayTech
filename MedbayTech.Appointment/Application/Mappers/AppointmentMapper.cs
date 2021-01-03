using Application.DTO;
using Domain.Enums;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Application.Mappers
{
    public class AppointmentMapper
    {
        public static List<AvailableAppointmentsDTO> AppointmentsToAvailableAppointmentsDTO(List<Appointment> appointments)
        {
            List<AvailableAppointmentsDTO> availableAppointmentsDTO = new List<AvailableAppointmentsDTO>();

            foreach(Appointment appointmentIt in appointments)
            {
                AvailableAppointmentsDTO dto = new AvailableAppointmentsDTO
                {
                    Start = appointmentIt.Period.StartTime,
                    End = appointmentIt.Period.EndTime,
                };
                availableAppointmentsDTO.Add(dto);
            }
            return availableAppointmentsDTO;
        }

        public static List<GetAppointmentDTO> ListAppointmentToListGetAppointmentDTO(List<Appointment> appointments)
        {
            List<GetAppointmentDTO> appointmentList = new List<GetAppointmentDTO>();
            foreach (Appointment appointmentIt in appointments)
            {
                int id = appointmentIt.Id;
                DateTime start = appointmentIt.Period.StartTime;
                DateTime end = appointmentIt.Period.EndTime;
                String typeOfAppointment = appointmentIt.TypeOfAppointment.ToString();
                bool finished = appointmentIt.Finished;
                bool canceledByPatient = appointmentIt.CanceledByPatient;
                string doctorId = appointmentIt.DoctorId;
                string name = appointmentIt.Doctor.Name;
                string surname = appointmentIt.Doctor.Surname;

                appointmentList.Add(new GetAppointmentDTO(id, start, end, typeOfAppointment, finished, canceledByPatient, doctorId, name, surname));
            }
            return appointmentList;
        }

        public static List<AvailableAppointmentsDTO> AppointmentsToAvailableAppointmentsDTOWithDoctor(List<Appointment> appointments)
        {
            List<AvailableAppointmentsDTO> availableAppointmentsDTO = new List<AvailableAppointmentsDTO>();

            foreach (Appointment appointmentIt in appointments)
            {
                AvailableAppointmentsDTO dto = new AvailableAppointmentsDTO
                {
                    Start = appointmentIt.Period.StartTime,
                    End = appointmentIt.Period.EndTime,
                    DoctorId = appointmentIt.DoctorId,
                    DoctorFullName = appointmentIt.Doctor.Name + " " + appointmentIt.Doctor.Surname
                };
                availableAppointmentsDTO.Add(dto);
            }
            return availableAppointmentsDTO;
        }

        public static Appointment ScheduleAppointmentDTOToAppointment(ScheduleAppointmentDTO dto)
        {
            return new Appointment
            {
                DoctorId = dto.DoctorId,
                Period = new Period(dto.StartTime, dto.EndTime),
                RoomId = 1
            };
        }

        public static PriorityParameters SearchAppointmentsDTOToPriorityParameters(SearchAppointmentsDTO dto)
        {
            return new PriorityParameters
            {
                DoctorId = dto.DoctorId,
                ChosenStartDate = dto.StartInterval,
                ChosenEndDate = dto.EndInterval,
                Priority = IntToPriorityType(dto.Priority),
                SpecializationName = dto.SpecializationName

            };
        }

        private static PriorityType IntToPriorityType(int priority)
        {
            if (priority == 1)
                return PriorityType.doctor;
            
            return PriorityType.date;
        }
    }
}
