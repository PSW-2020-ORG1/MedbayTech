using MedbayTech.PatientDocuments.Domain.Entities.Examinations.Enums;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Application.DTO.Report
{
    public class AppointmentReportDTO
    {
        public DateTime StartTime { get; set; }
        public String Type { get; set; }
        public List<DiagnosisDTO> Diagnosis { get; set; }
        public String DoctorName { get; set; }
        public String DoctorSurname { get; set; }

        public AppointmentReportDTO() { }
        public AppointmentReportDTO(DateTime startTime, String type, List<DiagnosisDTO> diagnosis, String docotorName, String doctorSurname) 
        {
            this.StartTime = startTime;
            this.Type = type;
            this.Diagnosis = diagnosis;
            this.DoctorName = docotorName;
            this.DoctorSurname = doctorSurname;
        }
    }
}
