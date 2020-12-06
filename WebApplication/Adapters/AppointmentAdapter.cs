using Backend.Utils.DTO;
using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                };
                availableAppointmentsDTO.Add(dto);
            }
            return availableAppointmentsDTO;
        }
    }
}
