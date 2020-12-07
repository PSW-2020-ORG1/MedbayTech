using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Utils.DTO;

namespace WebApplication.Validators
{
    public class ValidateScheduleAppointment : ValidateScheduleAppointmentDate
    {
        public static void Validate(ScheduleAppointmentDTO dto)
        {
            IsPast(dto);
        }
    }
}
