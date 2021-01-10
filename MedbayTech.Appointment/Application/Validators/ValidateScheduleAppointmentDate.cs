using Application.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace MedbayTech.Appointment.Application.Validators
{
    public class ValidateScheduleAppointmentDate
    {
        private const int hoursLimit = 24;
        public static void IsPast(ScheduleAppointmentDTO dto)
        {
            DateTime appointmentDate = dto.StartTime;
            if (appointmentDate <= DateTime.Now)
                throw new ValidationException("Can not schedule appointment in past");
        }

        public static void IsBeforeLimit(ScheduleAppointmentDTO dto)
        {
            DateTime appointmentDate = dto.StartTime;

            if ((appointmentDate - DateTime.Now).Hours < 24)
                throw new ValidationException("Can not schedule appointment");
        }
    }
}
