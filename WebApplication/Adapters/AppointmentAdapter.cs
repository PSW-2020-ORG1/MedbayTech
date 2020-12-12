using Backend.Utils.DTO;
using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.ScheduleService;

namespace WebApplication.Adapters
{
    public class AppointmentAdapter
    {
        public static List<AvailableAppointmentsDTO> Transform(List<Appointment> appointments)
        {
            List<AvailableAppointmentsDTO> availableAppointmentsDTO = new List<AvailableAppointmentsDTO>();

            foreach(Appointment appointmentIt in appointments)
            {
                AvailableAppointmentsDTO dto = new AvailableAppointmentsDTO
                {
                    Start = appointmentIt.Start,
                    End = appointmentIt.End,
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
                Start = dto.StartTime,
                End = dto.EndTime,
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
                SpecializationId = dto.SpecializationId
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
