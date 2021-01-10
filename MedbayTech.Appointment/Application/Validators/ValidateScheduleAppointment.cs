
using Application.DTO;

namespace MedbayTech.Appointment.Application.Validators
{
    public class ValidateScheduleAppointment : ValidateScheduleAppointmentDate
    {
        public static void Validate(ScheduleAppointmentDTO dto)
        {
            IsPast(dto);
        }
    }
}
