namespace Application.DTO
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
