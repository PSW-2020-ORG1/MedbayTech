using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    public class CancelAppointmentDTO
    {
        public int AppointmentId;
        public CancelAppointmentDTO() { }
        public CancelAppointmentDTO(int appointmentId) 
        {
            AppointmentId = appointmentId;
        }
    }
}
