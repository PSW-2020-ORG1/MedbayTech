using MedbayTech.Appointment.Domain.Exceptions;
using System;

namespace Application.DTO
{
    public class ScheduleAppointmentDTO
    {
        public string DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PatientId { get; set; }
        public int SpecializationId { get; set; }
        public ScheduleAppointmentDTO() {}

        public ScheduleAppointmentDTO(string doctorId, DateTime startTime, DateTime endTime, string patientId, int specializationId)
        {
            DoctorId = doctorId;
            SpecializationId = specializationId;
            PatientId = patientId;
            if(ValidateDates(startTime, endTime))
            {
                StartTime = startTime;
                EndTime = endTime;
            }
        }

        private bool ValidateDates(DateTime Start, DateTime End)
        {
            if(!StartBeforeEnd(Start, End))
            {
                throw new InvalidDateException("Start date must be after End date");
            }
            if(!StartInFuture(Start))
            {
                throw new InvalidDateException("Start date cannot be in the past");
            }
            return true;
        }

        private bool StartBeforeEnd(DateTime Start, DateTime End)
            => DateTime.Compare(Start, End) < 0;

        private bool StartInFuture(DateTime Start)
            => DateTime.Compare(Start, DateTime.Now) < 0;

    }
}
