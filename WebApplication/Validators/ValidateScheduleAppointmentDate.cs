using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Examinations.Exceptions;
using Backend.Utils.DTO;

namespace WebApplication.Validators
{
    public class ValidateScheduleAppointmentDate
    {
        private const int hoursLimit = 24;
        public static void IsPast(ScheduleAppointmentDTO dto)
        {
            DateTime appointmentDate = dto.StartTime;
            if(appointmentDate <= DateTime.Now)
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
