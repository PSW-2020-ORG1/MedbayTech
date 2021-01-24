using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Application.DTO.Report
{
    public class AppointmentDTO
    {
        public DateTime StartTime;
        public String DoctorId;
        public AppointmentDTO() { }
        public AppointmentDTO(DateTime startTime, String doctorId)
        {
            this.StartTime = startTime;
            this.DoctorId = doctorId;
        }
    }
}
