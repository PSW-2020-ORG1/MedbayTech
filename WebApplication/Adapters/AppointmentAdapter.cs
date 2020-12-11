﻿using Backend.Utils.DTO;
using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Adapters
{
    public class AppointmentAdapter
    {
        public static List<GetAppointmentDTO> ListAppointmentToListGetAppointmentDTO(List<Appointment> appointments)
        {
            List<GetAppointmentDTO> appointmentList = new List<GetAppointmentDTO>();
            foreach (Appointment appointmentIt in appointments)
            {
                int id = appointmentIt.Id;
                DateTime start = appointmentIt.Start;
                DateTime end = appointmentIt.End;
                String typeOfAppointment = appointmentIt.TypeOfAppointment.ToString();
                bool finished = appointmentIt.Finished;
                bool canceledByPatient = appointmentIt.CanceledByPatient;
                int roomNumber = appointmentIt.Room.RoomNumber;
                string roomType = appointmentIt.Room.RoomType.ToString();
                string doctorId = appointmentIt.DoctorId;
                string name = appointmentIt.Doctor.Name;
                string surname = appointmentIt.Doctor.Surname;

                appointmentList.Add(new GetAppointmentDTO(id, start, end, typeOfAppointment, finished, canceledByPatient, roomNumber, roomType, doctorId, name, surname));
            }
            return appointmentList;
        }
        
        public static List<AvailableAppointmentsDTO> Transform(List<Appointment> appointments)
        {
            List<AvailableAppointmentsDTO> availableAppointmentsDTO = new List<AvailableAppointmentsDTO>();

            foreach(Appointment appointmentIt in appointments)
            {
                AvailableAppointmentsDTO dto = new AvailableAppointmentsDTO
                {
                    Start = appointmentIt.Start,
                    End = appointmentIt.End,
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
                Start = dto.StartTime,
                End = dto.EndTime,
                RoomId = 1
            };
        }
    }
}
